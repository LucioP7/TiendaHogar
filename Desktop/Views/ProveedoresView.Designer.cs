namespace TiendaHogarDesktop.Views
{
    partial class ProveedoresView
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
            panel1 = new Panel();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPageLista = new TabPage();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            txtFiltro = new TextBox();
            label7 = new Label();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            btnEditar = new FontAwesome.Sharp.IconButton();
            btnAgregar = new FontAwesome.Sharp.IconButton();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            dataGridProveedoresView = new DataGridView();
            tabPageEditarAgregar = new TabPage();
            comboLocalidades = new ComboBox();
            label6 = new Label();
            txtCbu = new TextBox();
            label3 = new Label();
            txtTelefonos = new TextBox();
            label5 = new Label();
            txtDireccion = new TextBox();
            label4 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            label8 = new Label();
            comboIva = new ComboBox();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProveedoresView).BeginInit();
            tabPageEditarAgregar.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(938, 42);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 9);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(157, 32);
            label1.TabIndex = 0;
            label1.Text = "Proveedores";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageLista);
            tabControl1.Controls.Add(tabPageEditarAgregar);
            tabControl1.Location = new Point(1, 46);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(938, 468);
            tabControl1.TabIndex = 3;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(iconButton1);
            tabPageLista.Controls.Add(txtFiltro);
            tabPageLista.Controls.Add(label7);
            tabPageLista.Controls.Add(btnEliminar);
            tabPageLista.Controls.Add(btnEditar);
            tabPageLista.Controls.Add(btnAgregar);
            tabPageLista.Controls.Add(btnBuscar);
            tabPageLista.Controls.Add(dataGridProveedoresView);
            tabPageLista.Location = new Point(4, 24);
            tabPageLista.Margin = new Padding(2);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Size = new Size(930, 440);
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
            iconButton1.Location = new Point(805, 240);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(106, 40);
            iconButton1.TabIndex = 9;
            iconButton1.Text = "Salir";
            iconButton1.UseVisualStyleBackColor = false;
            iconButton1.Click += iconButton1_Click;
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(122, 11);
            txtFiltro.Margin = new Padding(2);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(675, 23);
            txtFiltro.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 14);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(102, 15);
            label7.TabIndex = 15;
            label7.Text = "Buscar proveedor:";
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.BackColor = Color.Firebrick;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnEliminar.IconColor = Color.White;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.IconSize = 28;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(803, 194);
            btnEliminar.Margin = new Padding(2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(108, 41);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eli&minar";
            btnEliminar.TextAlign = ContentAlignment.MiddleRight;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditar.BackColor = Color.DodgerBlue;
            btnEditar.ForeColor = Color.White;
            btnEditar.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            btnEditar.IconColor = Color.White;
            btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEditar.IconSize = 28;
            btnEditar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditar.Location = new Point(803, 146);
            btnEditar.Margin = new Padding(2);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(108, 44);
            btnEditar.TabIndex = 13;
            btnEditar.Text = "&Editar";
            btnEditar.TextAlign = ContentAlignment.MiddleRight;
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.BackColor = Color.SeaGreen;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            btnAgregar.IconColor = Color.White;
            btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregar.IconSize = 28;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(803, 93);
            btnAgregar.Margin = new Padding(2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(108, 49);
            btnAgregar.TabIndex = 12;
            btnAgregar.Text = "&Agregar";
            btnAgregar.TextAlign = ContentAlignment.MiddleRight;
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.BackColor = Color.SteelBlue;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = Color.White;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.IconSize = 28;
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(803, 6);
            btnBuscar.Margin = new Padding(2);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(108, 42);
            btnBuscar.TabIndex = 11;
            btnBuscar.Text = "&Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dataGridProveedoresView
            // 
            dataGridProveedoresView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridProveedoresView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProveedoresView.Location = new Point(2, 38);
            dataGridProveedoresView.Margin = new Padding(2);
            dataGridProveedoresView.Name = "dataGridProveedoresView";
            dataGridProveedoresView.RowHeadersWidth = 62;
            dataGridProveedoresView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProveedoresView.Size = new Size(793, 330);
            dataGridProveedoresView.TabIndex = 17;
            // 
            // tabPageEditarAgregar
            // 
            tabPageEditarAgregar.Controls.Add(comboIva);
            tabPageEditarAgregar.Controls.Add(label8);
            tabPageEditarAgregar.Controls.Add(comboLocalidades);
            tabPageEditarAgregar.Controls.Add(label6);
            tabPageEditarAgregar.Controls.Add(txtCbu);
            tabPageEditarAgregar.Controls.Add(label3);
            tabPageEditarAgregar.Controls.Add(txtTelefonos);
            tabPageEditarAgregar.Controls.Add(label5);
            tabPageEditarAgregar.Controls.Add(txtDireccion);
            tabPageEditarAgregar.Controls.Add(label4);
            tabPageEditarAgregar.Controls.Add(txtNombre);
            tabPageEditarAgregar.Controls.Add(label2);
            tabPageEditarAgregar.Controls.Add(btnCancelar);
            tabPageEditarAgregar.Controls.Add(btnGuardar);
            tabPageEditarAgregar.Location = new Point(4, 24);
            tabPageEditarAgregar.Margin = new Padding(2);
            tabPageEditarAgregar.Name = "tabPageEditarAgregar";
            tabPageEditarAgregar.Size = new Size(930, 440);
            tabPageEditarAgregar.TabIndex = 1;
            tabPageEditarAgregar.Text = "Editar/Agregar";
            tabPageEditarAgregar.UseVisualStyleBackColor = true;
            // 
            // comboLocalidades
            // 
            comboLocalidades.DropDownStyle = ComboBoxStyle.DropDownList;
            comboLocalidades.Location = new Point(388, 231);
            comboLocalidades.Margin = new Padding(2);
            comboLocalidades.Name = "comboLocalidades";
            comboLocalidades.Size = new Size(200, 23);
            comboLocalidades.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(310, 233);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 23;
            label6.Text = "Localidad:";
            // 
            // txtCbu
            // 
            txtCbu.Location = new Point(388, 158);
            txtCbu.Margin = new Padding(2);
            txtCbu.Name = "txtCbu";
            txtCbu.Size = new Size(200, 23);
            txtCbu.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(290, 166);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 21;
            label3.Text = "Cuit:";
            // 
            // txtTelefonos
            // 
            txtTelefonos.Location = new Point(388, 121);
            txtTelefonos.Margin = new Padding(2);
            txtTelefonos.Name = "txtTelefonos";
            txtTelefonos.Size = new Size(200, 23);
            txtTelefonos.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(283, 123);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 19;
            label5.Text = "Telefonos:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(388, 69);
            txtDireccion.Margin = new Padding(2);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(200, 23);
            txtDireccion.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(284, 71);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 18;
            label4.Text = "Direccion:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(388, 23);
            txtNombre.Margin = new Padding(2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(290, 25);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 14;
            label2.Text = "Nombre:";
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(499, 295);
            btnCancelar.Margin = new Padding(2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 48);
            btnCancelar.TabIndex = 13;
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
            btnGuardar.Location = new Point(262, 295);
            btnGuardar.Margin = new Padding(2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 48);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "&Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleRight;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(290, 201);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(83, 15);
            label8.TabIndex = 24;
            label8.Text = "Condicion Iva:";
            // 
            // comboIva
            // 
            comboIva.DropDownStyle = ComboBoxStyle.DropDownList;
            comboIva.Location = new Point(388, 198);
            comboIva.Margin = new Padding(2);
            comboIva.Name = "comboIva";
            comboIva.Size = new Size(200, 23);
            comboIva.TabIndex = 25;
            // 
            // ProveedoresView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 449);
            ControlBox = false;
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "ProveedoresView";
            Text = "Tienda Hogar - Proveedores";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProveedoresView).EndInit();
            tabPageEditarAgregar.ResumeLayout(false);
            tabPageEditarAgregar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPageLista;
        private TabPage tabPageEditarAgregar;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtTelefonos;
        private Label label5;
        private TextBox txtDireccion;
        private Label label4;
        private TextBox txtCbu;
        private Label label3;
        private ComboBox comboLocalidades;
        private Label label6;
        private DataGridView dataGridProveedoresView;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private TextBox txtFiltro;
        private Label label7;
        private FontAwesome.Sharp.IconButton iconButton1;
        private ComboBox comboIva;
        private Label label8;
    }
}