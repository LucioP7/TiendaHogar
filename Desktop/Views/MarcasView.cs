using Service.Models;
using Service.Services;
using Service.Interfaces;

namespace TiendaHogarDesktop.Views
{
    public partial class MarcasView : Form
    {
        private readonly IGenericService<Marca> marcaService = new GenericService<Marca>();
        private readonly BindingSource listaMarcas = new();
        private Marca? marcaCurrent;
        private readonly ErrorProvider errorProvider = new();
        public MarcasView()
        {
            InitializeComponent();
            Text = "Tienda Hogar - Marcas";
            dataGridMarcas.DataSource = listaMarcas;
            dataGridMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridMarcas.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            Shown += async (_, _) => await CargarGrilla();
        }
        private async Task CargarGrilla(string? filtro = null)
        {
            try
            {
                listaMarcas.DataSource = await marcaService.GetAllAsync(filtro);
                if (dataGridMarcas.Columns.Contains("Eliminado"))
                    dataGridMarcas.Columns["Eliminado"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando marcas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            marcaCurrent = null; Limpiar(); tabControl.SelectTab(tabPageEditarAgregar);
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            marcaCurrent = (Marca?)listaMarcas.Current;
            if (marcaCurrent == null) { MessageBox.Show("Seleccione una marca", "Atención"); return; }
            txtNombre.Text = marcaCurrent.Nombre;
            tabControl.SelectTab(tabPageEditarAgregar);
        }
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            marcaCurrent = (Marca?)listaMarcas.Current;
            if (marcaCurrent == null) { MessageBox.Show("Seleccione una marca", "Atención"); return; }
            if (MessageBox.Show($"¿Eliminar marca {marcaCurrent.Nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try { await marcaService.DeleteAsync(marcaCurrent.Id); await CargarGrilla(); }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
            }
            marcaCurrent = null;
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            try
            {
                if (marcaCurrent != null)
                {
                    marcaCurrent.Nombre = txtNombre.Text;
                    await marcaService.UpdateAsync(marcaCurrent);
                    marcaCurrent = null;
                }
                else
                {
                    var marca = new Marca { Nombre = txtNombre.Text };
                    await marcaService.AddAsync(marca);
                }
                await CargarGrilla();
                Limpiar();
                tabControl.SelectTab(tabPageLista);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        { marcaCurrent = null; Limpiar(); tabControl.SelectTab(tabPageLista); }
        private async void btnBuscar_Click(object sender, EventArgs e) => await CargarGrilla(txtFiltro.Text);
        private async void txtFiltro_TextChanged(object sender, EventArgs e) => await CargarGrilla(txtFiltro.Text);
        private bool Validar()
        { errorProvider.Clear(); if (string.IsNullOrWhiteSpace(txtNombre.Text)) { errorProvider.SetError(txtNombre, "Nombre obligatorio"); return false; } return true; }
        private void Limpiar() { txtNombre.Text = string.Empty; errorProvider.Clear(); }
    }
}
