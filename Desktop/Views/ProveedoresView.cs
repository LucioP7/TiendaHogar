using Service.Interfaces;
using Service.Models;
using Service.Services;
using System.ComponentModel;

namespace TiendaHogarDesktop.Views
{
    public partial class ProveedoresView : Form
    {
        private readonly IGenericService<Proveedor> proveedorService = new GenericService<Proveedor>();
        private readonly IGenericService<Localidad> localidadService = new GenericService<Localidad>();
        private readonly BindingSource ListProveedores = new();
        private Proveedor? proveedorCurrent;
        private readonly ErrorProvider errorProvider = new();

        public ProveedoresView()
        {
            InitializeComponent();
            Text = "Tienda Hogar - Proveedores";
            dataGridProveedoresView.DataSource = ListProveedores;
            dataGridProveedoresView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProveedoresView.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            Shown += async (_, _) =>
            {
                await CargarCombo();
                await CargarGrilla();
            };
        }

        private async Task CargarCombo()
        {
            try
            {
                comboLocalidades.DataSource = await localidadService.GetAllAsync(null);
                comboLocalidades.DisplayMember = "Nombre";
                comboLocalidades.ValueMember = "Id";
                comboLocalidades.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando localidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarGrilla(string? filtro = null)
        {
            try
            {
                var proveedores = await proveedorService.GetAllAsync(filtro);
                ListProveedores.DataSource = proveedores;
                OcultarColumnasNavegacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OcultarColumnasNavegacion()
        {
            if (dataGridProveedoresView.Columns.Contains("Localidad"))
                dataGridProveedoresView.Columns["Localidad"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            proveedorCurrent = null;
            LimpiarCampos();
            tabControl1.SelectTab(tabPageEditarAgregar);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            try
            {
                if (proveedorCurrent != null)
                {
                    proveedorCurrent.Nombre = txtNombre.Text;
                    proveedorCurrent.Direccion = txtDireccion.Text;
                    proveedorCurrent.Telefonos = txtTelefonos.Text;
                    proveedorCurrent.Cuit = txtCbu.Text; // usar CUIT
                    proveedorCurrent.LocalidadId = (int)comboLocalidades.SelectedValue!;
                    await proveedorService.UpdateAsync(proveedorCurrent);
                    proveedorCurrent = null;
                }
                else
                {
                    var proveedor = new Proveedor
                    {
                        Nombre = txtNombre.Text,
                        Direccion = txtDireccion.Text,
                        Telefonos = txtTelefonos.Text,
                        Cuit = txtCbu.Text,
                        LocalidadId = (int)comboLocalidades.SelectedValue!
                    };
                    await proveedorService.AddAsync(proveedor);
                }
                await CargarGrilla();
                LimpiarCampos();
                tabControl1.SelectTab(tabPageLista);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error guardando proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            proveedorCurrent = null;
            LimpiarCampos();
            tabControl1.SelectTab(tabPageLista);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            proveedorCurrent = (Proveedor?)ListProveedores.Current;
            if (proveedorCurrent == null)
            {
                MessageBox.Show("Seleccione un proveedor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtNombre.Text = proveedorCurrent.Nombre;
            txtDireccion.Text = proveedorCurrent.Direccion;
            txtTelefonos.Text = proveedorCurrent.Telefonos;
            txtCbu.Text = proveedorCurrent.Cuit;
            comboLocalidades.SelectedValue = proveedorCurrent.LocalidadId ?? -1;
            tabControl1.SelectTab(tabPageEditarAgregar);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            proveedorCurrent = (Proveedor?)ListProveedores.Current;
            if (proveedorCurrent == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = MessageBox.Show($"¿Está seguro que desea eliminar el proveedor {proveedorCurrent.Nombre}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await proveedorService.DeleteAsync(proveedorCurrent.Id);
                    await CargarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error eliminando proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            proveedorCurrent = null;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await CargarGrilla(txtFiltro.Text);
        }

        private bool ValidarCampos()
        {
            errorProvider.Clear();
            bool ok = true;
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider.SetError(txtNombre, "Nombre obligatorio");
                ok = false;
            }
            if (comboLocalidades.SelectedIndex < 0)
            {
                errorProvider.SetError(comboLocalidades, "Seleccione una localidad");
                ok = false;
            }
            return ok;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefonos.Text = string.Empty;
            txtCbu.Text = string.Empty;
            comboLocalidades.SelectedIndex = -1;
            errorProvider.Clear();
        }
    }
}
