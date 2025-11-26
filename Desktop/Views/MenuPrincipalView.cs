using TiendaHogarDesktop.ViewReports;
using TiendaHogarDesktop.Views;

namespace TiendaHogarDesktop
{
    public partial class MenuPrincipalView : Form
    {
        public MenuPrincipalView()
        {
            InitializeComponent();
            Text = "Tienda Hogar - Menú Principal";
        }

        private void ItemMenuSalirDelSistema_Click(object sender, EventArgs e) => Application.Exit();
        private void ItemMenuLocalidades_Click(object sender, EventArgs e) => new LocalidadesView { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
        private void iconMenuItem4_Click(object sender, EventArgs e) => new ProductosView { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
        private void iconMenuItem5_Click(object sender, EventArgs e) => new ClientesView { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e) => new LocalidadesViewReport { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
        private void iconMenuItem7_Click(object sender, EventArgs e) => new ProveedoresView { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
        private void iconMenuItem8_Click(object sender, EventArgs e) => new VentasView { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
        private void iconMenuItem9_Click(object sender, EventArgs e) => new CategoriasView { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
        private void iconMenuItem10_Click(object sender, EventArgs e) => new MarcasView { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
        private void productosReporteToolStripMenuItem_Click(object sender, EventArgs e) => new ProductosViewReport { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
        private void clientesReporteToolStripMenuItem_Click(object sender, EventArgs e) => new ClientesViewReport { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
        private void proveedoresReporteToolStripMenuItem_Click(object sender, EventArgs e) => new ProveedoresViewReport { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
    }
}
