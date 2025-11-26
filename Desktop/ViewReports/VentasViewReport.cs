using Microsoft.Reporting.WinForms;
using Service.Interfaces;
using Service.Models;
using Service.Services;

namespace TiendaHogarDesktop.ViewReports
{
    public partial class VentasViewReport : Form
    {
        private ReportViewer reporte;
        private readonly IGenericService<Venta> ventaService = new GenericService<Venta>();
        public VentasViewReport()
        {
            InitializeComponent();
            reporte = new ReportViewer { Dock = DockStyle.Fill };
            Controls.Add(reporte);
        }
        private async void VentasViewReport_Load(object sender, EventArgs e)
        {
            try
            {
                Text = "Tienda Hogar - Reporte de Ventas";
                reporte.LocalReport.ReportEmbeddedResource = "TiendaHogarDesktop.Reports.VentasReport.rdlc";
                var ventas = await ventaService.GetAllAsync(null);
                var datos = ventas?.Select(v => new { v.Id, v.Fecha, Cliente = v.Cliente?.Nombre, v.FormaPago, v.Total, v.Iva }).ToList();
                reporte.LocalReport.DataSources.Clear();
                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSVentas", datos));
                reporte.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando reporte de ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}