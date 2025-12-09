using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Service.Models;
using Service.Services;

namespace TiendaHogarDesktop.ViewReports
{
    public partial class FacturaViewReport : Form
    {
        private readonly int _ventaId;
        private ReportViewer _reporte;
        private readonly GenericService<Venta> _ventaService = new();
        private readonly GenericService<Producto> _productoService = new();
        private readonly GenericService<Cliente> _clienteService = new();
        private readonly GenericService<DetalleVenta> _detalleVentaService = new();

        public FacturaViewReport(int ventaId)
        {
            _ventaId = ventaId;
            _reporte = new ReportViewer { Dock = DockStyle.Fill };
            Controls.Add(_reporte);
            Load += FacturaViewReport_Load;
        }

        private async void FacturaViewReport_Load(object? sender, EventArgs e)
        {
            try
            {
                Text = "Tienda Hogar - Factura";
                // Change to your actual RDLC resource name for invoice
                _reporte.LocalReport.ReportEmbeddedResource = "TiendaHogarDesktop.Reports.FacturaReport.rdlc";

                var venta = await _ventaService.GetByIdAsync(_ventaId);
                if (venta == null)
                {
                    MessageBox.Show("No se encontró la venta para generar la factura.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                // Ensure cliente info is available
                var cliente = venta.Cliente;
                if (cliente == null && venta.ClienteId > 0)
                    cliente = await _clienteService.GetByIdAsync(venta.ClienteId);

                // Prepare master data source
                var cabecera = new[]
                {
                    new
                    {
                        Id = venta.Id.ToString(),
                        Fecha = venta.Fecha.ToString("d/M/yyyy HH:mm"),
                        ClienteNombre = cliente?.Nombre ?? string.Empty,
                        ClienteDni = cliente?.Dni ?? string.Empty,
                        ClienteDireccion = cliente?.Direccion ?? string.Empty,
                        FormaPago = venta.FormaPago.ToString(),
                        Total = venta.Total.ToString("0.00"),
                        Iva = venta.Iva.ToString("0.00")
                    }
                };

                // Build detalles; if navigation not loaded, fetch from service and filter by VentaId
                var detallesRaw = venta.DetallesVenta?.ToList() ?? new List<DetalleVenta>();
                if (detallesRaw.Count == 0)
                {
                    var allDetalles = await _detalleVentaService.GetAllAsync(null);
                    detallesRaw = allDetalles?.Where(d => d.VentaId == _ventaId).ToList() ?? new List<DetalleVenta>();
                }

                var detalles = new List<object>();
                foreach (var d in detallesRaw)
                {
                    var nombre = d.Producto?.Nombre;
                    if (string.IsNullOrEmpty(nombre) && d.ProductoId > 0)
                    {
                        var prod = await _productoService.GetByIdAsync(d.ProductoId);
                        nombre = prod?.Nombre ?? string.Empty;
                    }

                    detalles.Add(new
                    {
                        ProductoId = d.ProductoId.ToString(),
                        ProductoNombre = nombre ?? string.Empty,
                        Cantidad = d.Cantidad.ToString(),
                        PrecioUnitario = d.PrecioUnitario.ToString("0.00"),
                        SubTotal = (d.Cantidad * d.PrecioUnitario).ToString("0.00")
                    });
                }

                _reporte.LocalReport.DataSources.Clear();
                _reporte.LocalReport.DataSources.Add(new ReportDataSource("DSFacturaCabecera", cabecera));
                _reporte.LocalReport.DataSources.Add(new ReportDataSource("DSFacturaDetalle", detalles));
                _reporte.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
