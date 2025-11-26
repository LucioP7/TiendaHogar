using TiendaHogarDesktop.ExtensionMethods;
using Service.Enums;
using Service.Models;
using Service.Services;

namespace TiendaHogarDesktop.Views
{
    public partial class VentasView : Form
    {
        private readonly GenericService<Cliente> clienteService = new();
        private readonly GenericService<Producto> productoService = new();
        private readonly GenericService<Venta> ventaService = new();
        private Venta venta = new();
        private readonly ErrorProvider errorProvider = new();

        public VentasView()
        {
            InitializeComponent();
            Text = "Tienda Hogar - Ventas";
            AjustePantalla();
        }

        private async void AjustePantalla()
        {
            try
            {
                var clientesTask = clienteService.GetAllAsync(null);
                var productosTask = productoService.GetAllAsync(null);
                await Task.WhenAll(clientesTask, productosTask);

                comboBoxClientes.DataSource = clientesTask.Result;
                comboBoxClientes.DisplayMember = "Nombre";
                comboBoxClientes.ValueMember = "Id";

                comboBoxProductos.DataSource = productosTask.Result;
                comboBoxProductos.DisplayMember = "Nombre";
                comboBoxProductos.ValueMember = "Id";
                comboBoxProductos.SelectedIndex = -1;

                comboBoxFormasDePago.DataSource = Enum.GetValues(typeof(FormaDePagoEnum));
                numericPrecio.Value = 0;
                numericCantidad.Value = 1;
                gridDetallesVenta.DataSource = venta.DetallesVenta.ToList();
                EstilizarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos de venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstilizarGrilla()
        {
            gridDetallesVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridDetallesVenta.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
        }

        private void comboBoxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProductos.SelectedIndex != -1)
            {
                var producto = (Producto)comboBoxProductos.SelectedItem;
                numericPrecio.Value = producto.Precio;
            }
            BtnAgregar.Enabled = comboBoxProductos.SelectedIndex != -1;
            CalcularSubtotal();
        }

        private void numericCantidad_ValueChanged(object sender, EventArgs e) => CalcularSubtotal();
        private void numericPrecio_ValueChanged(object sender, EventArgs e) => CalcularSubtotal();

        private void CalcularSubtotal() => numericSubtotal.Value = numericPrecio.Value * numericCantidad.Value;

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (comboBoxProductos.SelectedIndex == -1) return;
            var detalleVenta = new DetalleVenta
            {
                Producto = (Producto)comboBoxProductos.SelectedItem,
                ProductoId = (int)comboBoxProductos.SelectedValue!,
                Cantidad = (int)numericCantidad.Value,
                PrecioUnitario = numericPrecio.Value
            };
            venta.DetallesVenta.Add(detalleVenta);
            ActualizarDetalles();
            comboBoxProductos.SelectedIndex = -1;
            comboBoxProductos.Focus();
            ActualizarTotalFactura();
        }

        private void ActualizarDetalles()
        {
            gridDetallesVenta.DataSource = null;
            gridDetallesVenta.DataSource = venta.DetallesVenta.ToList();
        }

        private void ActualizarTotalFactura() => numericTotal.Value = venta.DetallesVenta.Sum(dv => dv.Cantidad * dv.PrecioUnitario);

        private void gridDetallesVenta_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gridDetallesVenta.OcultarColumnas(new[] { "Id", "Venta", "VentaId", "ProductoId", "Eliminado" });
            BtnQuitar.Enabled = gridDetallesVenta.Rows.Count > 0;
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (gridDetallesVenta.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un detalle de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var detalleVenta = (DetalleVenta)gridDetallesVenta.CurrentRow.DataBoundItem;
            venta.DetallesVenta.Remove(detalleVenta);
            ActualizarDetalles();
            ActualizarTotalFactura();
        }

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            if (!ValidarVenta()) return;
            try
            {
                venta.ClienteId = (int)comboBoxClientes.SelectedValue!;
                venta.FormaPago = (FormaDePagoEnum)comboBoxFormasDePago.SelectedValue!;
                venta.Fecha = DateTime.Now;
                venta.Total = numericTotal.Value;
                venta.Iva = venta.Total * 0.21m;
                venta.Cliente = null;
                foreach (var dv in venta.DetallesVenta) dv.Producto = null; // reemplazo ForEach
                foreach (var dv in venta.DetallesVenta) dv.Venta = null; // reemplazo ForEach
                await ventaService.AddAsync(venta);
                MessageBox.Show("Venta registrada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                venta = new Venta();
                ActualizarDetalles();
                ActualizarTotalFactura();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registrando venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarVenta()
        {
            errorProvider.Clear();
            bool ok = true;
            if (comboBoxClientes.SelectedIndex < 0)
            {
                errorProvider.SetError(comboBoxClientes, "Seleccione un cliente");
                ok = false;
            }
            if (!venta.DetallesVenta.Any())
            {
                MessageBox.Show("Debe agregar al menos un producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }
    }
}
