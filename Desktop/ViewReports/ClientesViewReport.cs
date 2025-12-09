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
            reporte = new ReportViewer { Dock = DockStyle.Fill, ProcessingMode = ProcessingMode.Local };
            Controls.Add(reporte);
        }
        private async void ClientesViewReport_Load(object sender, EventArgs e)
        {
            try
            {
                Text = "Tienda Hogar - Listado de Clientes";
                // Asegúrate de que el RDLC está marcado como Embedded Resource y el nombre calificado es correcto
                reporte.LocalReport.ReportEmbeddedResource = "TiendaHogarDesktop.Reports.ClientesReport.rdlc";

                var clientes = await clienteService.GetAllAsync(null) ?? new List<Cliente>();
                var datos = clientes.Select(c => new
                {
                    c.Id,
                    c.Nombre,
                    c.Dni,
                    c.Email,
                    c.Telefono
                }).ToList();

                reporte.LocalReport.DataSources.Clear();
                // Debe coincidir con el Name del DataSet en el RDLC (p. ej., DataSet1)
                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSClientes", datos));

                reporte.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando reporte clientes: {ex.Message}");
            }
        }
    }
}
