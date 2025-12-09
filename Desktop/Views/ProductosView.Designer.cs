namespace TiendaHogarDesktop.Views
{
    partial class ProductosView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            tabControl = new TabControl();
            tabPageLista = new TabPage();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            BtnBuscar = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            txtFiltro = new TextBox();
            iconButtonEliminar = new FontAwesome.Sharp.IconButton();
            iconButtonEditar = new FontAwesome.Sharp.IconButton();
            iconButtonAgregar = new FontAwesome.Sharp.IconButton();
            dataGridProductosView = new DataGridView();
            tabPageAgregarEditar = new TabPage();
            labelDescripcion = new Label();
            txtDescripcion = new TextBox();
            labelCategoria = new Label();
            comboCategorias = new ComboBox();
            labelMarca = new Label();
            comboMarcas = new ComboBox();
            labelProveedor = new Label();
            comboProveedores = new ComboBox();
            checkOferta = new CheckBox();
            numericPrecio = new NumericUpDown();
            txtPrecio = new Label();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            txtNombre = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProductosView).BeginInit();
            tabPageAgregarEditar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericPrecio).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(907, 45);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 7);
            label1.Name = "label1";
            label1.Size = new Size(131, 32);
            label1.TabIndex = 0;
            label1.Text = "Productos";
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageLista);
            tabControl.Controls.Add(tabPageAgregarEditar);
            tabControl.Location = new Point(0, 51);
            tabControl.Margin = new Padding(3, 2, 3, 2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(899, 442);
            tabControl.TabIndex = 2;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(iconButton1);
            tabPageLista.Controls.Add(BtnBuscar);
            tabPageLista.Controls.Add(label3);
            tabPageLista.Controls.Add(txtFiltro);
            tabPageLista.Controls.Add(iconButtonEliminar);
            tabPageLista.Controls.Add(iconButtonEditar);
            tabPageLista.Controls.Add(iconButtonAgregar);
            tabPageLista.Controls.Add(dataGridProductosView);
            tabPageLista.Location = new Point(4, 24);
            tabPageLista.Margin = new Padding(3, 2, 3, 2);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Size = new Size(891, 414);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButton1.BackColor = Color.OrangeRed;
            iconButton1.ForeColor = Color.White;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.X;
            iconButton1.IconColor = Color.White;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 28;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(760, 291);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(108, 52);
            iconButton1.TabIndex = 9;
            iconButton1.Text = "Salir";
            iconButton1.UseVisualStyleBackColor = false;
            iconButton1.Click += iconButton1_Click;
            // 
            // BtnBuscar
            // 
            BtnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnBuscar.BackColor = Color.SteelBlue;
            BtnBuscar.ForeColor = Color.White;
            BtnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            BtnBuscar.IconColor = Color.White;
            BtnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnBuscar.Location = new Point(760, 10);
            BtnBuscar.Margin = new Padding(3, 2, 3, 2);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(108, 45);
            BtnBuscar.TabIndex = 9;
            BtnBuscar.Text = "&Buscar";
            BtnBuscar.TextAlign = ContentAlignment.MiddleRight;
            BtnBuscar.UseVisualStyleBackColor = false;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 11);
            label3.Name = "label3";
            label3.Size = new Size(97, 15);
            label3.TabIndex = 8;
            label3.Text = "Buscar producto:";
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(142, 11);
            txtFiltro.Margin = new Padding(3, 2, 3, 2);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(597, 23);
            txtFiltro.TabIndex = 7;
            txtFiltro.TextChanged += txtFiltro_TextChanged;
            // 
            // iconButtonEliminar
            // 
            iconButtonEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButtonEliminar.BackColor = Color.Firebrick;
            iconButtonEliminar.ForeColor = Color.White;
            iconButtonEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            iconButtonEliminar.IconColor = Color.White;
            iconButtonEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonEliminar.IconSize = 32;
            iconButtonEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonEliminar.Location = new Point(760, 220);
            iconButtonEliminar.Margin = new Padding(3, 2, 3, 2);
            iconButtonEliminar.Name = "iconButtonEliminar";
            iconButtonEliminar.Size = new Size(108, 55);
            iconButtonEliminar.TabIndex = 6;
            iconButtonEliminar.Text = "Eli&minar";
            iconButtonEliminar.TextAlign = ContentAlignment.MiddleRight;
            iconButtonEliminar.UseVisualStyleBackColor = false;
            iconButtonEliminar.Click += iconButtonEliminar_Click;
            // 
            // iconButtonEditar
            // 
            iconButtonEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButtonEditar.BackColor = Color.DodgerBlue;
            iconButtonEditar.ForeColor = Color.White;
            iconButtonEditar.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            iconButtonEditar.IconColor = Color.White;
            iconButtonEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonEditar.IconSize = 32;
            iconButtonEditar.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonEditar.Location = new Point(760, 146);
            iconButtonEditar.Margin = new Padding(3, 2, 3, 2);
            iconButtonEditar.Name = "iconButtonEditar";
            iconButtonEditar.Size = new Size(108, 56);
            iconButtonEditar.TabIndex = 5;
            iconButtonEditar.Text = "&Editar";
            iconButtonEditar.TextAlign = ContentAlignment.MiddleRight;
            iconButtonEditar.UseVisualStyleBackColor = false;
            iconButtonEditar.Click += iconButtonEditar_Click;
            // 
            // iconButtonAgregar
            // 
            iconButtonAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButtonAgregar.BackColor = Color.SeaGreen;
            iconButtonAgregar.ForeColor = Color.White;
            iconButtonAgregar.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            iconButtonAgregar.IconColor = Color.White;
            iconButtonAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonAgregar.IconSize = 32;
            iconButtonAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonAgregar.Location = new Point(760, 73);
            iconButtonAgregar.Margin = new Padding(3, 2, 3, 2);
            iconButtonAgregar.Name = "iconButtonAgregar";
            iconButtonAgregar.Size = new Size(108, 59);
            iconButtonAgregar.TabIndex = 4;
            iconButtonAgregar.Text = "&Agregar";
            iconButtonAgregar.TextAlign = ContentAlignment.MiddleRight;
            iconButtonAgregar.UseVisualStyleBackColor = false;
            iconButtonAgregar.Click += iconButtonAgregar_Click;
            // 
            // dataGridProductosView
            // 
            dataGridProductosView.AllowUserToAddRows = false;
            dataGridProductosView.AllowUserToDeleteRows = false;
            dataGridProductosView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProductosView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridProductosView.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridProductosView.Location = new Point(3, 44);
            dataGridProductosView.Margin = new Padding(3, 2, 3, 2);
            dataGridProductosView.Name = "dataGridProductosView";
            dataGridProductosView.ReadOnly = true;
            dataGridProductosView.RowHeadersWidth = 51;
            dataGridProductosView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProductosView.Size = new Size(736, 367);
            dataGridProductosView.TabIndex = 11;
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Controls.Add(labelDescripcion);
            tabPageAgregarEditar.Controls.Add(txtDescripcion);
            tabPageAgregarEditar.Controls.Add(labelCategoria);
            tabPageAgregarEditar.Controls.Add(comboCategorias);
            tabPageAgregarEditar.Controls.Add(labelMarca);
            tabPageAgregarEditar.Controls.Add(comboMarcas);
            tabPageAgregarEditar.Controls.Add(labelProveedor);
            tabPageAgregarEditar.Controls.Add(comboProveedores);
            tabPageAgregarEditar.Controls.Add(checkOferta);
            tabPageAgregarEditar.Controls.Add(numericPrecio);
            tabPageAgregarEditar.Controls.Add(txtPrecio);
            tabPageAgregarEditar.Controls.Add(btnCancelar);
            tabPageAgregarEditar.Controls.Add(btnGuardar);
            tabPageAgregarEditar.Controls.Add(txtNombre);
            tabPageAgregarEditar.Controls.Add(label2);
            tabPageAgregarEditar.Location = new Point(4, 24);
            tabPageAgregarEditar.Margin = new Padding(3, 2, 3, 2);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Size = new Size(891, 414);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Agregar/Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(299, 86);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(72, 15);
            labelDescripcion.TabIndex = 0;
            labelDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(389, 83);
            txtDescripcion.Margin = new Padding(3, 2, 3, 2);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(197, 23);
            txtDescripcion.TabIndex = 1;
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Location = new Point(299, 118);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(61, 15);
            labelCategoria.TabIndex = 2;
            labelCategoria.Text = "Categoría:";
            // 
            // comboCategorias
            // 
            comboCategorias.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCategorias.FormattingEnabled = true;
            comboCategorias.Location = new Point(389, 115);
            comboCategorias.Margin = new Padding(3, 2, 3, 2);
            comboCategorias.Name = "comboCategorias";
            comboCategorias.Size = new Size(197, 23);
            comboCategorias.TabIndex = 3;
            // 
            // labelMarca
            // 
            labelMarca.AutoSize = true;
            labelMarca.Location = new Point(299, 149);
            labelMarca.Name = "labelMarca";
            labelMarca.Size = new Size(43, 15);
            labelMarca.TabIndex = 4;
            labelMarca.Text = "Marca:";
            // 
            // comboMarcas
            // 
            comboMarcas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMarcas.FormattingEnabled = true;
            comboMarcas.Location = new Point(389, 146);
            comboMarcas.Margin = new Padding(3, 2, 3, 2);
            comboMarcas.Name = "comboMarcas";
            comboMarcas.Size = new Size(197, 23);
            comboMarcas.TabIndex = 5;
            // 
            // labelProveedor
            // 
            labelProveedor.AutoSize = true;
            labelProveedor.Location = new Point(299, 181);
            labelProveedor.Name = "labelProveedor";
            labelProveedor.Size = new Size(64, 15);
            labelProveedor.TabIndex = 6;
            labelProveedor.Text = "Proveedor:";
            // 
            // comboProveedores
            // 
            comboProveedores.DropDownStyle = ComboBoxStyle.DropDownList;
            comboProveedores.FormattingEnabled = true;
            comboProveedores.Location = new Point(389, 178);
            comboProveedores.Margin = new Padding(3, 2, 3, 2);
            comboProveedores.Name = "comboProveedores";
            comboProveedores.Size = new Size(197, 23);
            comboProveedores.TabIndex = 7;
            // 
            // checkOferta
            // 
            checkOferta.AutoSize = true;
            checkOferta.Location = new Point(389, 212);
            checkOferta.Margin = new Padding(3, 2, 3, 2);
            checkOferta.Name = "checkOferta";
            checkOferta.Size = new Size(59, 19);
            checkOferta.TabIndex = 11;
            checkOferta.Text = "Oferta";
            // 
            // numericPrecio
            // 
            numericPrecio.DecimalPlaces = 2;
            numericPrecio.Location = new Point(389, 240);
            numericPrecio.Margin = new Padding(3, 2, 3, 2);
            numericPrecio.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericPrecio.Name = "numericPrecio";
            numericPrecio.Size = new Size(197, 23);
            numericPrecio.TabIndex = 12;
            numericPrecio.TextAlign = HorizontalAlignment.Right;
            // 
            // txtPrecio
            // 
            txtPrecio.AutoSize = true;
            txtPrecio.Location = new Point(299, 242);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(43, 15);
            txtPrecio.TabIndex = 13;
            txtPrecio.Text = "Precio:";
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(514, 308);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 52);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleRight;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(277, 308);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 52);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "&Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleRight;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(389, 46);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(197, 23);
            txtNombre.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(299, 49);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 15;
            label2.Text = "Nombre:";
            // 
            // ProductosView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(906, 502);
            ControlBox = false;
            Controls.Add(tabControl);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProductosView";
            Text = "Tienda Hogar - Productos";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProductosView).EndInit();
            tabPageAgregarEditar.ResumeLayout(false);
            tabPageAgregarEditar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericPrecio).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TabControl tabControl;
        private TabPage tabPageLista;
        private FontAwesome.Sharp.IconButton iconButtonEliminar;
        private FontAwesome.Sharp.IconButton iconButtonEditar;
        private FontAwesome.Sharp.IconButton iconButtonAgregar;
        private DataGridView dataGridProductosView;
        private TabPage tabPageAgregarEditar;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private TextBox txtNombre;
        private Label label2;
        private NumericUpDown numericPrecio;
        private Label txtPrecio;
        private Label label3;
        private TextBox txtFiltro;
        private FontAwesome.Sharp.IconButton BtnBuscar;
        private TextBox txtDescripcion;
        private Label labelDescripcion;
        private ComboBox comboCategorias;
        private Label labelCategoria;
        private ComboBox comboMarcas;
        private Label labelMarca;
        private ComboBox comboProveedores;
        private Label labelProveedor;
        private CheckBox checkOferta;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}