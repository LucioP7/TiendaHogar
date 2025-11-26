using Service.Interfaces;
using Service.Services;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace TiendaHogarDesktop.ViewReports
{
    public partial class LocalidadesViewReport : Form
    {
        private ReportViewer reporte;
        private readonly IGenericService<Service.Models.Localidad> localidadService = new GenericService<Service.Models.Localidad>();
        public LocalidadesViewReport()
        {
            InitializeComponent();
            reporte = new ReportViewer();
            reporte.Dock = DockStyle.Fill;
            Controls.Add(reporte);
        }

        private async void LocalidadesViewReport_Load(object sender, EventArgs e)
        {
            try
            {
                Text = "Tienda Hogar - Listado de Localidades";
                reporte.LocalReport.ReportEmbeddedResource = "TiendaHogarDesktop.Reports.LocalidadesReport.rdlc"; // ajustar si nombre cambia
                var localidades = await localidadService.GetAllAsync(null);
                reporte.LocalReport.DataSources.Clear();
                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSLocalidades", localidades));
                reporte.SetDisplayMode(DisplayMode.PrintLayout);
                reporte.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando reporte de localidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
