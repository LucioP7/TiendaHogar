namespace TiendaHogarDesktop.ViewReports
{
    partial class CategoriasViewReport : Form
    {
        private System.ComponentModel.IContainer? components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(900, 600);
            Name = "CategoriasViewReport";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tienda Hogar - Reporte de Categorías";
            Load += CategoriasViewReport_Load;
            ResumeLayout(false);
        }
    }
}
