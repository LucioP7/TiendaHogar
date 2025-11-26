using Service.Interfaces;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaHogarDesktop.Views
{
    public partial class ProductosView : Form
    {
        private readonly IGenericService<Producto> productoService = new GenericService<Producto>();
        private readonly IGenericService<Categoria> categoriaService = new GenericService<Categoria>();
        private readonly IGenericService<Marca> marcaService = new GenericService<Marca>();
        private readonly IGenericService<Proveedor> proveedorService = new GenericService<Proveedor>();
        private readonly BindingSource ListProductos = new();
        private List<Producto> ListaAFiltrar = new();
        private Producto? productoCurrent;
        private readonly ErrorProvider errorProvider = new();

        public ProductosView()
        {
            InitializeComponent();
            Text = "Tienda Hogar - Productos";
            dataGridProductosView.DataSource = ListProductos;
            dataGridProductosView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProductosView.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            Shown += async (_, _) => { await CargarCombos(); await CargarGrilla(); };
        }

        private async Task CargarCombos()
        {
            try
            {
                var categoriasTask = categoriaService.GetAllAsync(null);
                var marcasTask = marcaService.GetAllAsync(null);
                var proveedoresTask = proveedorService.GetAllAsync(null);
                await Task.WhenAll(categoriasTask, marcasTask, proveedoresTask);
                comboCategorias.DataSource = categoriasTask.Result;
                comboCategorias.DisplayMember = "Nombre";
                comboCategorias.ValueMember = "Id";
                comboCategorias.SelectedIndex = -1;
                comboMarcas.DataSource = marcasTask.Result;
                comboMarcas.DisplayMember = "Nombre";
                comboMarcas.ValueMember = "Id";
                comboMarcas.SelectedIndex = -1;
                comboProveedores.DataSource = proveedoresTask.Result;
                comboProveedores.DisplayMember = "Nombre";
                comboProveedores.ValueMember = "Id";
                comboProveedores.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando combos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarGrilla()
        {
            try
            {
                var productos = await productoService.GetAllAsync(null);
                ListProductos.DataSource = productos;
                ListaAFiltrar = productos ?? new List<Producto>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iconButtonAgregar_Click(object sender, EventArgs e)
        {
            productoCurrent = null;
            LimpiarCampos();
            tabControl.SelectTab(tabPageAgregarEditar);
        }

        private void iconButtonEditar_Click(object sender, EventArgs e)
        {
            productoCurrent = (Producto?)ListProductos.Current;
            if (productoCurrent == null)
            {
                MessageBox.Show("Seleccione un producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtNombre.Text = productoCurrent.Nombre;
            txtDescripcion.Text = productoCurrent.Descripcion;
            numericPrecio.Value = productoCurrent.Precio;
            checkOferta.Checked = productoCurrent.Oferta;
            comboCategorias.SelectedValue = productoCurrent.CategoriaId;
            comboMarcas.SelectedValue = productoCurrent.MarcaId;
            comboProveedores.SelectedValue = productoCurrent.ProveedorId;
            tabControl.SelectTab(tabPageAgregarEditar);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            try
            {
                if (productoCurrent != null)
                {
                    productoCurrent.Nombre = txtNombre.Text;
                    productoCurrent.Descripcion = txtDescripcion.Text;
                    productoCurrent.Precio = numericPrecio.Value;
                    productoCurrent.CategoriaId = (int)comboCategorias.SelectedValue!;
                    productoCurrent.MarcaId = (int)comboMarcas.SelectedValue!;
                    productoCurrent.ProveedorId = (int)comboProveedores.SelectedValue!;
                    productoCurrent.Oferta = checkOferta.Checked;
                    await productoService.UpdateAsync(productoCurrent);
                    productoCurrent = null;
                }
                else
                {
                    var producto = new Producto
                    {
                        Nombre = txtNombre.Text,
                        Descripcion = txtDescripcion.Text,
                        Precio = numericPrecio.Value,
                        CategoriaId = (int)comboCategorias.SelectedValue!,
                        MarcaId = (int)comboMarcas.SelectedValue!,
                        ProveedorId = (int)comboProveedores.SelectedValue!,
                        Oferta = checkOferta.Checked
                    };
                    await productoService.AddAsync(producto);
                }
                await CargarGrilla();
                LimpiarCampos();
                tabControl.SelectTab(tabPageLista);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error guardando producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            tabControl.SelectTab(tabPageLista);
        }

        private async void iconButtonEliminar_Click(object sender, EventArgs e)
        {
            productoCurrent = ListProductos.Current as Producto;
            if (productoCurrent == null)
            {
                MessageBox.Show("Seleccione un producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var result = MessageBox.Show("¿Está seguro que desea eliminar el producto?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await productoService.DeleteAsync(productoCurrent.Id);
                    await CargarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error eliminando producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void FiltrarProductos()
        {
            var texto = txtFiltro.Text.Trim().ToUpperInvariant();
            var productosFiltrados = ListaAFiltrar.Where(p => p.Nombre?.ToUpperInvariant().Contains(texto) == true).ToList();
            ListProductos.DataSource = productosFiltrados;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e) => FiltrarProductos();

        private bool ValidarCampos()
        {
            errorProvider.Clear();
            bool ok = true;
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { errorProvider.SetError(txtNombre, "Nombre obligatorio"); ok = false; }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text)) { errorProvider.SetError(txtDescripcion, "Descripción obligatoria"); ok = false; }
            if (numericPrecio.Value <= 0) { errorProvider.SetError(numericPrecio, "Precio > 0"); ok = false; }
            if (comboCategorias.SelectedIndex < 0) { errorProvider.SetError(comboCategorias, "Seleccione categoría"); ok = false; }
            if (comboMarcas.SelectedIndex < 0) { errorProvider.SetError(comboMarcas, "Seleccione marca"); ok = false; }
            if (comboProveedores.SelectedIndex < 0) { errorProvider.SetError(comboProveedores, "Seleccione proveedor"); ok = false; }
            return ok;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            numericPrecio.Value = 0;
            checkOferta.Checked = false;
            comboCategorias.SelectedIndex = -1;
            comboMarcas.SelectedIndex = -1;
            comboProveedores.SelectedIndex = -1;
            errorProvider.Clear();
        }
    }
}
