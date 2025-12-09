using Service.Interfaces;
using Service.Models;
using Service.Services;
using TiendaHogarDesktop.ExtensionMethods;

namespace TiendaHogarDesktop.Views
{
    public partial class LocalidadesView : Form
    {
        private readonly IGenericService<Localidad> localidadService = new GenericService<Localidad>();
        private readonly BindingSource listaLocalidades = new();
        private Localidad? localidadCurrent;
        private readonly ErrorProvider errorProvider = new();

        public LocalidadesView()
        {
            InitializeComponent();
            Text = "Tienda Hogar - Localidades";
            dataGridLocalidades.DataSource = listaLocalidades;
            dataGridLocalidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridLocalidades.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            Shown += async (_, _) => await CargarGrilla();
        }

        private async Task CargarGrilla(string? filtro = null)
        {
            try
            {
                var localidades = await localidadService.GetAllAsync(filtro);
                // Bind directly to entities coming from the database
                listaLocalidades.DataSource = localidades;
                dataGridLocalidades.OcultarId();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando localidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            localidadCurrent = null;
            LimpiarCampos();
            tabControl.SelectTab(tabPageAgregarEditar);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            try
            {
                if (localidadCurrent != null)
                {
                    localidadCurrent.Nombre = txtNombre.Text;
                    await localidadService.UpdateAsync(localidadCurrent);
                    localidadCurrent = null;
                }
                else
                {
                    var localidad = new Localidad { Nombre = txtNombre.Text };
                    await localidadService.AddAsync(localidad);
                }
                await CargarGrilla();
                LimpiarCampos();
                tabControl.SelectTab(tabPageLista);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error guardando localidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // With entities bound, Current is a Localidad
            localidadCurrent = listaLocalidades.Current as Localidad;
            if (localidadCurrent == null)
            {
                MessageBox.Show("Seleccione una localidad", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtNombre.Text = localidadCurrent.Nombre;
            tabControl.SelectTab(tabPageAgregarEditar);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            localidadCurrent = listaLocalidades.Current as Localidad;
            if (localidadCurrent == null)
            {
                MessageBox.Show("Seleccione una localidad", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var result = MessageBox.Show($"¿Está seguro que desea eliminar la localidad {localidadCurrent.Nombre}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await localidadService.DeleteAsync(localidadCurrent.Id);
                    await CargarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error eliminando localidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            localidadCurrent = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            localidadCurrent = null;
            LimpiarCampos();
            tabControl.SelectTab(tabPageLista);
        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            await CargarGrilla(txtFiltro.Text);
        }

        private bool Validar()
        {
            errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider.SetError(txtNombre, "Nombre obligatorio");
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            errorProvider.Clear();
        }

        // Handler faltante para evento txtFiltro_TextChanged en diseñador
        private async void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            await CargarGrilla(txtFiltro.Text);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
