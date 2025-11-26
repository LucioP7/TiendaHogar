using System;
using System.Linq;

namespace TiendaHogarDesktop.ExtensionMethods
{
    public static class MyExtensions
    {

        public static int IdSeleccionado(this ComboBox combo)
        {
            if (combo.SelectedValue != null && combo.SelectedValue.GetType() == typeof(int))
            {
                return (int)combo.SelectedValue;
            }
            else
                return 0;
        }
        public static string ObtenerColumna(this DataGridView grid, string columna)
        {
            if (grid.CurrentRow != null && grid.RowCount > 0)
                return grid.CurrentRow.Cells[columna].Value?.ToString() ?? string.Empty;
            else
                return string.Empty;
        }


        public static void MensajeAdvertenciaDeSalida(this Form form)
        {
            var respuesta = MessageBox.Show($"¿Está seguro que desea salir del formulario {form.Text}", "Atención", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
                form.Close();
        }
        public static int IdSeleccionado(this DataGridView grid)
        {
            return int.Parse(grid.CurrentRow?.Cells[0].Value?.ToString() ?? "0");
        }
        //método sobre las grillas que oculta las columnas que normalmente no se muestran




        public static void DarColorAFilas(this DataGridView grid, int nroColumna, Func<decimal, bool> condicion, Color color)
        {
            foreach (DataGridViewRow row in grid.Rows)
                if (row.Cells.Count > nroColumna &&
                    decimal.TryParse(row.Cells[nroColumna].Value?.ToString(), out var val) &&
                    condicion(val))
                {
                    row.DefaultCellStyle.BackColor = color;
                }
        }
        public static void SeleccionarFilaNuevaOEditada(this DataGridView grid, int id)
        {
            foreach (DataGridViewRow fila in grid.Rows)
            {
                if (fila.Cells[0].Value is int valor && valor == id)
                {
                    grid.CurrentCell = fila.Cells[0];
                    break;
                }
            }
        }

        public static void OcultarColumnas(this DataGridView grid, string[] columnasAOcultar)
        {
            if (grid.RowCount > 0)
            {
                foreach (string columnaAOcultar in columnasAOcultar)
                {
                    foreach (DataGridViewColumn columna in grid.Columns)
                    {
                        if (columna.Name == columnaAOcultar)
                        {
                            columna.Visible = false;
                        }
                    }
                }
            }
        }

        public static void EstablecerAnchoDeColumnas(this DataGridView grid, int[] anchos)
        {
            if (grid.ColumnCount > 0)
            {
                for (int i = 0; i < anchos.Length && i < grid.Columns.Count; i++)
                {
                    grid.Columns[i].Width = anchos[i];
                }
            }
        }

        public static bool EstaVisible(this Form form)
        {
            return Application.OpenForms.OfType<Form>().Any(f => f.Name == form.Name);
        }



    }
}
