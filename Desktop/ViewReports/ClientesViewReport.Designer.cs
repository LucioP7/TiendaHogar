namespace TiendaHogarDesktop.ViewReports
{
    partial class ClientesViewReport : Form
    {
        private System.ComponentModel.IContainer? components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(900, 600);
            Name = "ClientesViewReport";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tienda Hogar - Reporte de Clientes";
            Load += ClientesViewReport_Load;
            ResumeLayout(false);
        }
    }
}
