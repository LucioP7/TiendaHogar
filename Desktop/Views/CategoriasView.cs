using Service.Models;
using Service.Services;
using Service.Interfaces;

namespace TiendaHogarDesktop.Views
{
    public partial class CategoriasView : Form
    {
        private readonly IGenericService<Categoria> categoriaService = new GenericService<Categoria>();
        private readonly BindingSource listaCategorias = new();
        private Categoria? categoriaCurrent;
        private readonly ErrorProvider errorProvider = new();
        public CategoriasView()
        {
            InitializeComponent();
            Text = "Tienda Hogar - Categorías";
            dataGridCategorias.DataSource = listaCategorias;
            dataGridCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridCategorias.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            Shown += async (_, _) => await CargarGrilla();
        }
        private async Task CargarGrilla(string? filtro = null)
        {
            try
            {
                listaCategorias.DataSource = await categoriaService.GetAllAsync(filtro);
                if (dataGridCategorias.Columns.Contains("Eliminado"))
                    dataGridCategorias.Columns["Eliminado"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            categoriaCurrent = null;
            Limpiar();
            tabControl.SelectTab(tabPageEditarAgregar);
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            categoriaCurrent = (Categoria?)listaCategorias.Current;
            if (categoriaCurrent == null) { MessageBox.Show("Seleccione una categoría", "Atención"); return; }
            txtNombre.Text = categoriaCurrent.Nombre;
            txtDescripcion.Text = categoriaCurrent.Descripcion;
            tabControl.SelectTab(tabPageEditarAgregar);
        }
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            categoriaCurrent = (Categoria?)listaCategorias.Current;
            if (categoriaCurrent == null) { MessageBox.Show("Seleccione una categoría", "Atención"); return; }
            if (MessageBox.Show($"¿Eliminar categoría {categoriaCurrent.Nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await categoriaService.DeleteAsync(categoriaCurrent.Id);
                    await CargarGrilla();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
            }
            categoriaCurrent = null;
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            try
            {
                if (categoriaCurrent != null)
                {
                    categoriaCurrent.Nombre = txtNombre.Text;
                    categoriaCurrent.Descripcion = txtDescripcion.Text;
                    await categoriaService.UpdateAsync(categoriaCurrent);
                    categoriaCurrent = null;
                }
                else
                {
                    var categoria = new Categoria { Nombre = txtNombre.Text, Descripcion = txtDescripcion.Text };
                    await categoriaService.AddAsync(categoria);
                }
                await CargarGrilla();
                Limpiar();
                tabControl.SelectTab(tabPageLista);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            categoriaCurrent = null; Limpiar(); tabControl.SelectTab(tabPageLista);
        }
        private async void btnBuscar_Click(object sender, EventArgs e) => await CargarGrilla(txtFiltro.Text);
        private bool Validar()
        {
            errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { errorProvider.SetError(txtNombre, "Nombre obligatorio"); return false; }
            return true;
        }
        private void Limpiar()
        {
            txtNombre.Text = string.Empty; txtDescripcion.Text = string.Empty; errorProvider.Clear();
        }
        private async void txtFiltro_TextChanged(object sender, EventArgs e) => await CargarGrilla(txtFiltro.Text);
    }
}
