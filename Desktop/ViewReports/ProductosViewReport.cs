using Service.Models;
using Service.Services;
using Service.Interfaces;
using Microsoft.Reporting.WinForms;

namespace TiendaHogarDesktop.ViewReports
{
    public partial class ProductosViewReport : Form
    {
        private ReportViewer reporte;
        private readonly IGenericService<Producto> productoService = new GenericService<Producto>();
        public ProductosViewReport()
        {
            InitializeComponent();
            reporte = new ReportViewer { Dock = DockStyle.Fill };
            Controls.Add(reporte);
        }
        private async void ProductosViewReport_Load(object sender, EventArgs e)
        {
            try
            {
                Text = "Tienda Hogar - Listado de Productos";
                reporte.LocalReport.ReportEmbeddedResource = "TiendaHogarDesktop.Reports.ProductosReport.rdlc";
                var productos = await productoService.GetAllAsync(null);
                var datos = productos?.Select(p => new { p.Id, p.Nombre, p.Descripcion, p.Precio, Categoria = p.Categoria?.Nombre, Marca = p.Marca?.Nombre, Proveedor = p.Proveedor?.Nombre }).ToList();
                reporte.LocalReport.DataSources.Clear();
                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSProductos", datos));
                reporte.RefreshReport();
            }
            catch (Exception ex)
            { MessageBox.Show($"Error cargando reporte productos: {ex.Message}"); }
        }
    }
}
