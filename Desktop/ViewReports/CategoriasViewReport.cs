using Service.Models;
using Service.Services;
using Service.Interfaces;
using Microsoft.Reporting.WinForms;

namespace TiendaHogarDesktop.ViewReports
{
    public partial class CategoriasViewReport : Form
    {
        private ReportViewer reporte;
        private readonly IGenericService<Categoria> categoriaService = new GenericService<Categoria>();
        public CategoriasViewReport()
        {
            InitializeComponent();
            reporte = new ReportViewer { Dock = DockStyle.Fill, ProcessingMode = ProcessingMode.Local };
            Controls.Add(reporte);
        }
        private async void CategoriasViewReport_Load(object sender, EventArgs e)
        {
            try
            {
                Text = "Tienda Hogar - Listado de Categorías";
                // RDLC embebido para categorías                
                reporte.LocalReport.ReportEmbeddedResource = "TiendaHogarDesktop.Reports.CategoriasReport.rdlc";

                var categorias = await categoriaService.GetAllAsync(null) ?? new List<Categoria>();
                var datos = categorias.Select(c => new
                {
                    c.Id,
                    c.Nombre,
                    c.Descripcion
                }).ToList();

                reporte.LocalReport.DataSources.Clear();
                // Debe coincidir con el Name del DataSet en el RDLC
                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSCategorias", datos));

                reporte.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando reporte categorías: {ex.Message}");
            }
        }
    }
}
