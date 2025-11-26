namespace TiendaHogarDesktop.ViewReports
{
    partial class ProveedoresViewReport : Form
    {
        private System.ComponentModel.IContainer? components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(900, 600);
            Name = "ProveedoresViewReport";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tienda Hogar - Reporte de Proveedores";
            Load += ProveedoresViewReport_Load;
            ResumeLayout(false);
        }
    }
}
