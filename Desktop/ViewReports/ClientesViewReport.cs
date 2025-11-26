using Service.Models;
using Service.Services;
using Service.Interfaces;
using Microsoft.Reporting.WinForms;

namespace TiendaHogarDesktop.ViewReports
{
    public partial class ClientesViewReport : Form
    {
        private ReportViewer reporte;
        private readonly IGenericService<Cliente> clienteService = new GenericService<Cliente>();
        public ClientesViewReport()
        {
            InitializeComponent();
            reporte = new ReportViewer { Dock = DockStyle.Fill };
            Controls.Add(reporte);
        }
        private async void ClientesViewReport_Load(object sender, EventArgs e)
        {
            try
            {
                Text = "Tienda Hogar - Listado de Clientes";
                reporte.LocalReport.ReportEmbeddedResource = "TiendaHogarDesktop.Reports.ClientesReport.rdlc";
                var clientes = await clienteService.GetAllAsync(null);
                var datos = clientes?.Select(c => new { c.Id, c.Nombre, c.Dni, c.Email, c.Direccion, c.Telefono, Localidad = c.Localidad?.Nombre }).ToList();
                reporte.LocalReport.DataSources.Clear();
                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSClientes", datos));
                reporte.RefreshReport();
            }
            catch (Exception ex)
            { MessageBox.Show($"Error cargando reporte clientes: {ex.Message}"); }
        }
    }
}
