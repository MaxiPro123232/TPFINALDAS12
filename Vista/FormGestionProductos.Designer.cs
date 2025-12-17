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
            dgvProductos = new DataGridView();
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtPrecio = new TextBox();
            txtStock = new TextBox();
            cmbCategoria = new ComboBox();
            cmbSucursal = new ComboBox();
            btnLimpiar = new Button();
            btnCrear = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            lblCodigo = new Label();
            lblNombre = new Label();
            lblDescripcion = new Label();
            lblPrecio = new Label();
            lblStock = new Label();
            lblCategoria = new Label();
            lblSucursal = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            btnConsultar = new Button();
            txtNombreConsulta = new TextBox();
            cmbSucursalConsulta = new ComboBox();
            lblSucursalConsulta = new Label();
            lblNombreConsulta = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(20, 300);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(900, 300);
            dgvProductos.TabIndex = 0;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
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
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(120, 110);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(200, 60);
            txtDescripcion.TabIndex = 3;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(120, 190);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(200, 23);
            txtPrecio.TabIndex = 4;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(120, 230);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(200, 23);
            txtStock.TabIndex = 5;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(450, 30);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(200, 23);
            cmbCategoria.TabIndex = 6;
            // 
            // cmbSucursal
            // 
            cmbSucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(450, 70);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(200, 23);
            cmbSucursal.TabIndex = 7;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(450, 120);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(90, 30);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(550, 120);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(90, 30);
            btnCrear.TabIndex = 9;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Enabled = false;
            btnActualizar.Location = new Point(450, 160);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(90, 30);
            btnActualizar.TabIndex = 10;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Enabled = false;
            btnEliminar.Location = new Point(550, 160);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(90, 30);
            btnEliminar.TabIndex = 11;
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
            lblCodigo.TabIndex = 12;
            lblCodigo.Text = "Código:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 73);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 13;
            lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(20, 113);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(72, 15);
            lblDescripcion.TabIndex = 14;
            lblDescripcion.Text = "Descripción:";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(20, 193);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(43, 15);
            lblPrecio.TabIndex = 15;
            lblPrecio.Text = "Precio:";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(20, 233);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(39, 15);
            lblStock.TabIndex = 16;
            lblStock.Text = "Stock:";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(350, 33);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(61, 15);
            lblCategoria.TabIndex = 17;
            lblCategoria.Text = "Categoría:";
            // 
            // lblSucursal
            // 
            lblSucursal.AutoSize = true;
            lblSucursal.Location = new Point(350, 73);
            lblSucursal.Name = "lblSucursal";
            lblSucursal.Size = new Size(54, 15);
            lblSucursal.TabIndex = 18;
            lblSucursal.Text = "Sucursal:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblCodigo);
            groupBox1.Controls.Add(lblSucursal);
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Controls.Add(lblCategoria);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(lblStock);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(lblPrecio);
            groupBox1.Controls.Add(txtPrecio);
            groupBox1.Controls.Add(lblDescripcion);
            groupBox1.Controls.Add(txtStock);
            groupBox1.Controls.Add(lblNombre);
            groupBox1.Controls.Add(cmbCategoria);
            groupBox1.Controls.Add(cmbSucursal);
            groupBox1.Controls.Add(btnLimpiar);
            groupBox1.Controls.Add(btnCrear);
            groupBox1.Controls.Add(btnActualizar);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(680, 274);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Producto";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnConsultar);
            groupBox2.Controls.Add(txtNombreConsulta);
            groupBox2.Controls.Add(cmbSucursalConsulta);
            groupBox2.Controls.Add(lblSucursalConsulta);
            groupBox2.Controls.Add(lblNombreConsulta);
            groupBox2.Location = new Point(720, 20);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 270);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "Consultar Disponibilidad";
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(20, 120);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(160, 30);
            btnConsultar.TabIndex = 4;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // txtNombreConsulta
            // 
            txtNombreConsulta.Location = new Point(20, 91);
            txtNombreConsulta.Name = "txtNombreConsulta";
            txtNombreConsulta.Size = new Size(160, 23);
            txtNombreConsulta.TabIndex = 3;
            // 
            // cmbSucursalConsulta
            // 
            cmbSucursalConsulta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSucursalConsulta.FormattingEnabled = true;
            cmbSucursalConsulta.Location = new Point(20, 40);
            cmbSucursalConsulta.Name = "cmbSucursalConsulta";
            cmbSucursalConsulta.Size = new Size(160, 23);
            cmbSucursalConsulta.TabIndex = 2;
            // 
            // lblSucursalConsulta
            // 
            lblSucursalConsulta.AutoSize = true;
            lblSucursalConsulta.Location = new Point(20, 20);
            lblSucursalConsulta.Name = "lblSucursalConsulta";
            lblSucursalConsulta.Size = new Size(54, 15);
            lblSucursalConsulta.TabIndex = 1;
            lblSucursalConsulta.Text = "Sucursal:";
            // 
            // lblNombreConsulta
            // 
            lblNombreConsulta.AutoSize = true;
            lblNombreConsulta.Location = new Point(20, 71);
            lblNombreConsulta.Name = "lblNombreConsulta";
            lblNombreConsulta.Size = new Size(54, 15);
            lblNombreConsulta.TabIndex = 0;
            lblNombreConsulta.Text = "Nombre:";
            // 
            // FormGestionProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 620);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvProductos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormGestionProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Productos";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        private DataGridView dgvProductos;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private ComboBox cmbCategoria;
        private ComboBox cmbSucursal;
        private Button btnLimpiar;
        private Button btnCrear;
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

