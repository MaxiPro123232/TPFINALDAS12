namespace TechStore.Vistas
{
    partial class FormGestionVendedores
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
            this.dgvVendedores = new DataGridView();
            this.txtCodigo = new TextBox();
            this.txtNombre = new TextBox();
            this.txtApellido = new TextBox();
            this.txtTelefono = new TextBox();
            this.cmbSucursal = new ComboBox();
            this.btnNuevo = new Button();
            this.btnGuardar = new Button();
            this.btnActualizar = new Button();
            this.btnEliminar = new Button();
            this.lblCodigo = new Label();
            this.lblNombre = new Label();
            this.lblApellido = new Label();
            this.lblTelefono = new Label();
            this.lblSucursal = new Label();
            this.groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVendedores
            // 
            this.dgvVendedores.AllowUserToAddRows = false;
            this.dgvVendedores.AllowUserToDeleteRows = false;
            this.dgvVendedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedores.Location = new Point(20, 220);
            this.dgvVendedores.Name = "dgvVendedores";
            this.dgvVendedores.ReadOnly = true;
            this.dgvVendedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendedores.Size = new Size(700, 300);
            this.dgvVendedores.TabIndex = 0;
            this.dgvVendedores.SelectionChanged += new EventHandler(this.dgvVendedores_SelectionChanged);
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
            // txtApellido
            // 
            this.txtApellido.Location = new Point(120, 110);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new Size(200, 23);
            this.txtApellido.TabIndex = 3;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new Point(120, 150);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new Size(200, 23);
            this.txtTelefono.TabIndex = 4;
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new Point(450, 30);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new Size(200, 23);
            this.cmbSucursal.TabIndex = 5;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new Point(120, 180);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new Size(90, 30);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new Point(220, 180);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(90, 30);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Location = new Point(320, 180);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new Size(90, 30);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new Point(420, 180);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(90, 30);
            this.btnEliminar.TabIndex = 9;
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
            this.lblCodigo.TabIndex = 10;
            this.lblCodigo.Text = "Código:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new Point(20, 73);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(54, 15);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new Point(20, 113);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new Size(54, 15);
            this.lblApellido.TabIndex = 12;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new Point(20, 153);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new Size(55, 15);
            this.lblTelefono.TabIndex = 13;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new Point(350, 33);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new Size(57, 15);
            this.lblSucursal.TabIndex = 14;
            this.lblSucursal.Text = "Sucursal:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCodigo);
            this.groupBox1.Controls.Add(this.lblSucursal);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.lblTelefono);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblApellido);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.cmbSucursal);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnActualizar);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Location = new Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(700, 190);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Vendedor";
            // 
            // FormGestionVendedores
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(740, 540);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvVendedores);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGestionVendedores";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestión de Vendedores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        private DataGridView dgvVendedores;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private ComboBox cmbSucursal;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Label lblCodigo;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblTelefono;
        private Label lblSucursal;
        private GroupBox groupBox1;
    }
}

