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
            dgvVendedores = new DataGridView();
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtTelefono = new TextBox();
            cmbSucursal = new ComboBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            lblCodigo = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            lblTelefono = new Label();
            lblSucursal = new Label();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvVendedores).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvVendedores
            // 
            dgvVendedores.AllowUserToAddRows = false;
            dgvVendedores.AllowUserToDeleteRows = false;
            dgvVendedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVendedores.Location = new Point(20, 232);
            dgvVendedores.Name = "dgvVendedores";
            dgvVendedores.ReadOnly = true;
            dgvVendedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendedores.Size = new Size(700, 288);
            dgvVendedores.TabIndex = 0;
            dgvVendedores.SelectionChanged += dgvVendedores_SelectionChanged;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(120, 30);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(200, 23);
            txtCodigo.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 70);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(120, 110);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(200, 23);
            txtApellido.TabIndex = 3;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(120, 150);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 23);
            txtTelefono.TabIndex = 4;
            // 
            // cmbSucursal
            // 
            cmbSucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(450, 30);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(200, 23);
            cmbSucursal.TabIndex = 5;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(120, 180);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(90, 30);
            btnNuevo.TabIndex = 6;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(220, 180);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 30);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Enabled = false;
            btnActualizar.Location = new Point(320, 180);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(90, 30);
            btnActualizar.TabIndex = 8;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Enabled = false;
            btnEliminar.Location = new Point(420, 180);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(90, 30);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(20, 33);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(49, 15);
            lblCodigo.TabIndex = 10;
            lblCodigo.Text = "Código:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 73);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 11;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(20, 113);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 12;
            lblApellido.Text = "Apellido:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(20, 153);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(56, 15);
            lblTelefono.TabIndex = 13;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblSucursal
            // 
            lblSucursal.AutoSize = true;
            lblSucursal.Location = new Point(350, 33);
            lblSucursal.Name = "lblSucursal";
            lblSucursal.Size = new Size(54, 15);
            lblSucursal.TabIndex = 14;
            lblSucursal.Text = "Sucursal:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblCodigo);
            groupBox1.Controls.Add(lblSucursal);
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Controls.Add(lblTelefono);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(lblApellido);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(lblNombre);
            groupBox1.Controls.Add(txtTelefono);
            groupBox1.Controls.Add(cmbSucursal);
            groupBox1.Controls.Add(btnNuevo);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(btnActualizar);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(700, 206);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Vendedor";
            // 
            // FormGestionVendedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 540);
            Controls.Add(groupBox1);
            Controls.Add(dgvVendedores);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormGestionVendedores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Vendedores";
            ((System.ComponentModel.ISupportInitialize)dgvVendedores).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
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

