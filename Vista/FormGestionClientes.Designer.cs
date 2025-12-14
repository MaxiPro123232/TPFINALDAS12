namespace TechStore.Vistas
{
    partial class FormGestionClientes
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
            this.dgvClientes = new DataGridView();
            this.txtCodigo = new TextBox();
            this.txtNombre = new TextBox();
            this.txtApellido = new TextBox();
            this.txtDireccion = new TextBox();
            this.txtTelefono = new TextBox();
            this.txtEmail = new TextBox();
            this.txtDescuento = new TextBox();
            this.cmbTipoCliente = new ComboBox();
            this.btnNuevo = new Button();
            this.btnGuardar = new Button();
            this.btnActualizar = new Button();
            this.btnEliminar = new Button();
            this.btnHistorial = new Button();
            this.lblCodigo = new Label();
            this.lblNombre = new Label();
            this.lblApellido = new Label();
            this.lblDireccion = new Label();
            this.lblTelefono = new Label();
            this.lblEmail = new Label();
            this.lblTipoCliente = new Label();
            this.lblDescuento = new Label();
            this.groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new Point(20, 280);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new Size(800, 300);
            this.dgvClientes.TabIndex = 0;
            this.dgvClientes.SelectionChanged += new EventHandler(this.dgvClientes_SelectionChanged);
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
            // txtDireccion
            // 
            this.txtDireccion.Location = new Point(120, 150);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new Size(200, 23);
            this.txtDireccion.TabIndex = 4;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new Point(450, 30);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new Size(200, 23);
            this.txtTelefono.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new Point(450, 70);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(200, 23);
            this.txtEmail.TabIndex = 6;
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new Point(450, 150);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new Size(200, 23);
            this.txtDescuento.TabIndex = 8;
            // 
            // cmbTipoCliente
            // 
            this.cmbTipoCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipoCliente.FormattingEnabled = true;
            this.cmbTipoCliente.Location = new Point(450, 110);
            this.cmbTipoCliente.Name = "cmbTipoCliente";
            this.cmbTipoCliente.Size = new Size(200, 23);
            this.cmbTipoCliente.TabIndex = 7;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new Point(120, 200);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new Size(90, 30);
            this.btnNuevo.TabIndex = 9;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new Point(220, 200);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(90, 30);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Location = new Point(320, 200);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new Size(90, 30);
            this.btnActualizar.TabIndex = 11;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new Point(420, 200);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(90, 30);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new EventHandler(this.btnEliminar_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Enabled = false;
            this.btnHistorial.Location = new Point(520, 200);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new Size(130, 30);
            this.btnHistorial.TabIndex = 13;
            this.btnHistorial.Text = "Ver Historial Compras";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new EventHandler(this.btnHistorial_Click);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new Point(20, 33);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new Size(46, 15);
            this.lblCodigo.TabIndex = 14;
            this.lblCodigo.Text = "Código:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new Point(20, 73);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(54, 15);
            this.lblNombre.TabIndex = 15;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new Point(20, 113);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new Size(54, 15);
            this.lblApellido.TabIndex = 16;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new Point(20, 153);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new Size(60, 15);
            this.lblDireccion.TabIndex = 17;
            this.lblDireccion.Text = "Dirección:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new Point(350, 33);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new Size(55, 15);
            this.lblTelefono.TabIndex = 18;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(350, 73);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(39, 15);
            this.lblEmail.TabIndex = 19;
            this.lblEmail.Text = "Email:";
            // 
            // lblTipoCliente
            // 
            this.lblTipoCliente.AutoSize = true;
            this.lblTipoCliente.Location = new Point(350, 113);
            this.lblTipoCliente.Name = "lblTipoCliente";
            this.lblTipoCliente.Size = new Size(75, 15);
            this.lblTipoCliente.TabIndex = 20;
            this.lblTipoCliente.Text = "Tipo Cliente:";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new Point(350, 153);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new Size(65, 15);
            this.lblDescuento.TabIndex = 21;
            this.lblDescuento.Text = "Descuento:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCodigo);
            this.groupBox1.Controls.Add(this.lblDescuento);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.lblTipoCliente);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.lblTelefono);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.lblDireccion);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.lblApellido);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.cmbTipoCliente);
            this.groupBox1.Controls.Add(this.txtDescuento);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnActualizar);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnHistorial);
            this.groupBox1.Location = new Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(800, 250);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Cliente";
            // 
            // FormGestionClientes
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(840, 600);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvClientes);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGestionClientes";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestión de Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        private DataGridView dgvClientes;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private TextBox txtDescuento;
        private ComboBox cmbTipoCliente;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnHistorial;
        private Label lblCodigo;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblDireccion;
        private Label lblTelefono;
        private Label lblEmail;
        private Label lblTipoCliente;
        private Label lblDescuento;
        private GroupBox groupBox1;
    }
}

