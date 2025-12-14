namespace TechStore.Vistas
{
    partial class FormGestionProductos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvProductos = new DataGridView();
            this.txtCodigo = new TextBox();
            this.txtNombre = new TextBox();
            this.txtDescripcion = new TextBox();
            this.txtPrecio = new TextBox();
            this.txtStock = new TextBox();
            this.cmbCategoria = new ComboBox();
            this.cmbSucursal = new ComboBox();
            this.btnNuevo = new Button();
            this.btnGuardar = new Button();
            this.btnActualizar = new Button();
            this.btnEliminar = new Button();
            this.lblCodigo = new Label();
            this.lblNombre = new Label();
            this.lblDescripcion = new Label();
            this.lblPrecio = new Label();
            this.lblStock = new Label();
            this.lblCategoria = new Label();
            this.lblSucursal = new Label();
            this.groupBox1 = new GroupBox();
            this.groupBox2 = new GroupBox();
            this.btnConsultar = new Button();
            this.txtNombreConsulta = new TextBox();
            this.cmbSucursalConsulta = new ComboBox();
            this.lblSucursalConsulta = new Label();
            this.lblNombreConsulta = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new Point(20, 300);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new Size(900, 300);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.SelectionChanged += new EventHandler(this.dgvProductos_SelectionChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new Point(120, 30);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new Size(200, 23);
            this.txtCodigo.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new Point(120, 70);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(200, 23);
            this.txtNombre.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new Point(120, 110);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new Size(200, 60);
            this.txtDescripcion.TabIndex = 3;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new Point(120, 190);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new Size(200, 23);
            this.txtPrecio.TabIndex = 4;
            // 
            // txtStock
            // 
            this.txtStock.Location = new Point(120, 230);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new Size(200, 23);
            this.txtStock.TabIndex = 5;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new Point(450, 30);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new Size(200, 23);
            this.cmbCategoria.TabIndex = 6;
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new Point(450, 70);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new Size(200, 23);
            this.cmbSucursal.TabIndex = 7;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new Point(450, 120);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new Size(90, 30);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new Point(550, 120);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(90, 30);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Location = new Point(450, 160);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new Size(90, 30);
            this.btnActualizar.TabIndex = 10;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new Point(550, 160);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(90, 30);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new EventHandler(this.btnEliminar_Click);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new Point(20, 33);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new Size(46, 15);
            this.lblCodigo.TabIndex = 12;
            this.lblCodigo.Text = "Código:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new Point(20, 73);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(54, 15);
            this.lblNombre.TabIndex = 13;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new Point(20, 113);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new Size(70, 15);
            this.lblDescripcion.TabIndex = 14;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new Point(20, 193);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new Size(43, 15);
            this.lblPrecio.TabIndex = 15;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new Point(20, 233);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new Size(39, 15);
            this.lblStock.TabIndex = 16;
            this.lblStock.Text = "Stock:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new Point(350, 33);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new Size(61, 15);
            this.lblCategoria.TabIndex = 17;
            this.lblCategoria.Text = "Categoría:";
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new Point(350, 73);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new Size(57, 15);
            this.lblSucursal.TabIndex = 18;
            this.lblSucursal.Text = "Sucursal:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCodigo);
            this.groupBox1.Controls.Add(this.lblSucursal);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.lblCategoria);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblStock);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.lblPrecio);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.lblDescripcion);
            this.groupBox1.Controls.Add(this.txtStock);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.cmbCategoria);
            this.groupBox1.Controls.Add(this.cmbSucursal);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnActualizar);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Location = new Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(680, 270);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Producto";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConsultar);
            this.groupBox2.Controls.Add(this.txtNombreConsulta);
            this.groupBox2.Controls.Add(this.cmbSucursalConsulta);
            this.groupBox2.Controls.Add(this.lblSucursalConsulta);
            this.groupBox2.Controls.Add(this.lblNombreConsulta);
            this.groupBox2.Location = new Point(720, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(200, 270);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consultar Disponibilidad";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new Point(20, 120);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new Size(160, 30);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new EventHandler(this.btnConsultar_Click);
            // 
            // txtNombreConsulta
            // 
            this.txtNombreConsulta.Location = new Point(20, 80);
            this.txtNombreConsulta.Name = "txtNombreConsulta";
            this.txtNombreConsulta.Size = new Size(160, 23);
            this.txtNombreConsulta.TabIndex = 3;
            // 
            // cmbSucursalConsulta
            // 
            this.cmbSucursalConsulta.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSucursalConsulta.FormattingEnabled = true;
            this.cmbSucursalConsulta.Location = new Point(20, 40);
            this.cmbSucursalConsulta.Name = "cmbSucursalConsulta";
            this.cmbSucursalConsulta.Size = new Size(160, 23);
            this.cmbSucursalConsulta.TabIndex = 2;
            // 
            // lblSucursalConsulta
            // 
            this.lblSucursalConsulta.AutoSize = true;
            this.lblSucursalConsulta.Location = new Point(20, 20);
            this.lblSucursalConsulta.Name = "lblSucursalConsulta";
            this.lblSucursalConsulta.Size = new Size(57, 15);
            this.lblSucursalConsulta.TabIndex = 1;
            this.lblSucursalConsulta.Text = "Sucursal:";
            // 
            // lblNombreConsulta
            // 
            this.lblNombreConsulta.AutoSize = true;
            this.lblNombreConsulta.Location = new Point(20, 60);
            this.lblNombreConsulta.Name = "lblNombreConsulta";
            this.lblNombreConsulta.Size = new Size(54, 15);
            this.lblNombreConsulta.TabIndex = 0;
            this.lblNombreConsulta.Text = "Nombre:";
            // 
            // FormGestionProductos
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(940, 620);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvProductos);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGestionProductos";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestión de Productos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
        }

        private DataGridView dgvProductos;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private ComboBox cmbCategoria;
        private ComboBox cmbSucursal;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Label lblCodigo;
        private Label lblNombre;
        private Label lblDescripcion;
        private Label lblPrecio;
        private Label lblStock;
        private Label lblCategoria;
        private Label lblSucursal;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnConsultar;
        private TextBox txtNombreConsulta;
        private ComboBox cmbSucursalConsulta;
        private Label lblSucursalConsulta;
        private Label lblNombreConsulta;
    }
}

