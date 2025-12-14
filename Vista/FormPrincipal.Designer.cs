namespace TechStore.Vistas
{
    partial class FormPrincipal
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
            btnProductos = new Button();
            btnCategorias = new Button();
            btnClientes = new Button();
            btnVentas = new Button();
            btnReportes = new Button();
            btnSucursales = new Button();
            btnVendedores = new Button();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // btnProductos
            // 
            btnProductos.Location = new Point(30, 80);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(150, 50);
            btnProductos.TabIndex = 0;
            btnProductos.Text = "Gestión de Productos";
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.Location = new Point(200, 80);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(150, 50);
            btnCategorias.TabIndex = 1;
            btnCategorias.Text = "Gestión de Categorías";
            btnCategorias.UseVisualStyleBackColor = true;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnClientes
            // 
            btnClientes.Location = new Point(370, 80);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(150, 50);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Gestión de Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnVentas
            // 
            btnVentas.Location = new Point(540, 80);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(150, 50);
            btnVentas.TabIndex = 3;
            btnVentas.Text = "Gestión de Ventas";
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnReportes
            // 
            btnReportes.Location = new Point(30, 150);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(150, 50);
            btnReportes.TabIndex = 4;
            btnReportes.Text = "Reportes y Consultas";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnSucursales
            // 
            btnSucursales.Location = new Point(200, 150);
            btnSucursales.Name = "btnSucursales";
            btnSucursales.Size = new Size(150, 50);
            btnSucursales.TabIndex = 5;
            btnSucursales.Text = "Gestión de Sucursales";
            btnSucursales.UseVisualStyleBackColor = true;
            btnSucursales.Click += btnSucursales_Click;
            // 
            // btnVendedores
            // 
            btnVendedores.Location = new Point(370, 150);
            btnVendedores.Name = "btnVendedores";
            btnVendedores.Size = new Size(150, 50);
            btnVendedores.TabIndex = 6;
            btnVendedores.Text = "Gestión de Vendedores";
            btnVendedores.UseVisualStyleBackColor = true;
            btnVendedores.Click += btnVendedores_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.Location = new Point(155, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(416, 32);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "TechStore S.A. - Sistema de Gestión";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 240);
            Controls.Add(lblTitulo);
            Controls.Add(btnVendedores);
            Controls.Add(btnSucursales);
            Controls.Add(btnReportes);
            Controls.Add(btnVentas);
            Controls.Add(btnClientes);
            Controls.Add(btnCategorias);
            Controls.Add(btnProductos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TechStore - Sistema de Gestión de Ventas";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnProductos;
        private Button btnCategorias;
        private Button btnClientes;
        private Button btnVentas;
        private Button btnReportes;
        private Button btnSucursales;
        private Button btnVendedores;
        private Label lblTitulo;
    }
}

