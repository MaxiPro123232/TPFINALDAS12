namespace TechStore.Vistas
{
    partial class FormGestionSucursales
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
            this.dgvSucursales = new DataGridView();
            this.txtNombre = new TextBox();
            this.txtDireccion = new TextBox();
            this.txtTelefono = new TextBox();
            this.btnNuevo = new Button();
            this.btnGuardar = new Button();
            this.btnActualizar = new Button();
            this.lblNombre = new Label();
            this.lblDireccion = new Label();
            this.lblTelefono = new Label();
            this.groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSucursales
            // 
            this.dgvSucursales.AllowUserToAddRows = false;
            this.dgvSucursales.AllowUserToDeleteRows = false;
            this.dgvSucursales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSucursales.Location = new Point(20, 180);
            this.dgvSucursales.Name = "dgvSucursales";
            this.dgvSucursales.ReadOnly = true;
            this.dgvSucursales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSucursales.Size = new Size(600, 300);
            this.dgvSucursales.TabIndex = 0;
            this.dgvSucursales.SelectionChanged += new EventHandler(this.dgvSucursales_SelectionChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new Point(120, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(400, 23);
            this.txtNombre.TabIndex = 1;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new Point(120, 70);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new Size(400, 23);
            this.txtDireccion.TabIndex = 2;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new Point(120, 110);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new Size(400, 23);
            this.txtTelefono.TabIndex = 3;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new Point(120, 150);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new Size(90, 30);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new Point(220, 150);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(90, 30);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Location = new Point(320, 150);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new Size(90, 30);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new EventHandler(this.btnActualizar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new Point(20, 33);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(54, 15);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new Point(20, 73);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new Size(60, 15);
            this.lblDireccion.TabIndex = 8;
            this.lblDireccion.Text = "Dirección:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new Point(20, 113);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new Size(55, 15);
            this.lblTelefono.TabIndex = 9;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblDireccion);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.lblTelefono);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnActualizar);
            this.groupBox1.Location = new Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(600, 150);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Sucursal";
            // 
            // FormGestionSucursales
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(640, 500);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvSucursales);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGestionSucursales";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestión de Sucursales";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        private DataGridView dgvSucursales;
        private TextBox txtNombre;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnActualizar;
        private Label lblNombre;
        private Label lblDireccion;
        private Label lblTelefono;
        private GroupBox groupBox1;
    }
}

