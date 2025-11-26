using Service.Models;
using Service.Services;
using Service.Interfaces;
using Microsoft.Reporting.WinForms;

namespace TiendaHogarDesktop.ViewReports
{
    public partial class ProveedoresViewReport : Form
    {
        private ReportViewer reporte;
        private readonly IGenericService<Proveedor> proveedorService = new GenericService<Proveedor>();
        public ProveedoresViewReport()
        {
            InitializeComponent();
            reporte = new ReportViewer { Dock = DockStyle.Fill };
            Controls.Add(reporte);
        }
        private async void ProveedoresViewReport_Load(object sender, EventArgs e)
        {
            try
            {
                Text = "Tienda Hogar - Listado de Proveedores";
                // recurso embebido: TiendaHogarDesktop.Reports.ProveedoresReport.rdlc (debe agregarse externamente)
                reporte.LocalReport.ReportEmbeddedResource = "TiendaHogarDesktop.Reports.ProveedoresReport.rdlc";
                var proveedores = await proveedorService.GetAllAsync(null);
                var datos = proveedores?.Select(p => new { p.Id, p.Nombre, p.Direccion, p.Telefonos, p.Cuit, Localidad = p.Localidad?.Nombre }).ToList();
                reporte.LocalReport.DataSources.Clear();
                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSProveedores", datos));
                reporte.RefreshReport();
            }
            catch (Exception ex)
            { MessageBox.Show($"Error cargando reporte proveedores: {ex.Message}"); }
        }
    }
}
