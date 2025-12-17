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
            dgvSucursales = new DataGridView();
            txtNombre = new TextBox();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            btnLimpiar = new Button();
            btnCrear = new Button();
            btnActualizar = new Button();
            lblNombre = new Label();
            lblDireccion = new Label();
            lblTelefono = new Label();
            groupBox1 = new GroupBox();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSucursales).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvSucursales
            // 
            dgvSucursales.AllowUserToAddRows = false;
            dgvSucursales.AllowUserToDeleteRows = false;
            dgvSucursales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSucursales.Location = new Point(20, 213);
            dgvSucursales.Name = "dgvSucursales";
            dgvSucursales.ReadOnly = true;
            dgvSucursales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSucursales.Size = new Size(600, 300);
            dgvSucursales.TabIndex = 0;
            dgvSucursales.SelectionChanged += dgvSucursales_SelectionChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 30);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(400, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(120, 70);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(400, 23);
            txtDireccion.TabIndex = 2;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(120, 110);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(400, 23);
            txtTelefono.TabIndex = 3;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(107, 153);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(90, 30);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(207, 153);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(90, 30);
            btnCrear.TabIndex = 5;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Enabled = false;
            btnActualizar.Location = new Point(307, 153);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(90, 30);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 33);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 7;
            lblNombre.Text = "Nombre:";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(20, 73);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(60, 15);
            lblDireccion.TabIndex = 8;
            lblDireccion.Text = "Dirección:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(20, 113);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(56, 15);
            lblTelefono.TabIndex = 9;
            lblTelefono.Text = "Teléfono:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(lblNombre);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(lblDireccion);
            groupBox1.Controls.Add(txtDireccion);
            groupBox1.Controls.Add(lblTelefono);
            groupBox1.Controls.Add(txtTelefono);
            groupBox1.Controls.Add(btnLimpiar);
            groupBox1.Controls.Add(btnCrear);
            groupBox1.Controls.Add(btnActualizar);
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(600, 187);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de la Sucursal";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(414, 155);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(82, 26);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FormGestionSucursales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 545);
            Controls.Add(groupBox1);
            Controls.Add(dgvSucursales);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormGestionSucursales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Sucursales";
            ((System.ComponentModel.ISupportInitialize)dgvSucursales).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        private DataGridView dgvSucursales;
        private TextBox txtNombre;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private Button btnLimpiar;
        private Button btnCrear;
        private Button btnActualizar;
        private Label lblNombre;
        private Label lblDireccion;
        private Label lblTelefono;
        private GroupBox groupBox1;
        private Button btnEliminar;
    }
}

