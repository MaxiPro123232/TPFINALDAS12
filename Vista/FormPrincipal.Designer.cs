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
            this.btnProductos = new Button();
            this.btnCategorias = new Button();
            this.btnClientes = new Button();
            this.btnVentas = new Button();
            this.btnReportes = new Button();
            this.btnSucursales = new Button();
            this.btnVendedores = new Button();
            this.lblTitulo = new Label();
            this.SuspendLayout();
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new Point(30, 80);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new Size(150, 50);
            this.btnProductos.TabIndex = 0;
            this.btnProductos.Text = "Gestión de Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new EventHandler(this.btnProductos_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.Location = new Point(200, 80);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new Size(150, 50);
            this.btnCategorias.TabIndex = 1;
            this.btnCategorias.Text = "Gestión de Categorías";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new EventHandler(this.btnCategorias_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new Point(370, 80);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new Size(150, 50);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "Gestión de Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new EventHandler(this.btnClientes_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Location = new Point(540, 80);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new Size(150, 50);
            this.btnVentas.TabIndex = 3;
            this.btnVentas.Text = "Gestión de Ventas";
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new EventHandler(this.btnVentas_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new Point(30, 150);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new Size(150, 50);
            this.btnReportes.TabIndex = 4;
            this.btnReportes.Text = "Reportes y Consultas";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new EventHandler(this.btnReportes_Click);
            // 
            // btnSucursales
            // 
            this.btnSucursales.Location = new Point(200, 150);
            this.btnSucursales.Name = "btnSucursales";
            this.btnSucursales.Size = new Size(150, 50);
            this.btnSucursales.TabIndex = 5;
            this.btnSucursales.Text = "Gestión de Sucursales";
            this.btnSucursales.UseVisualStyleBackColor = true;
            this.btnSucursales.Click += new EventHandler(this.btnSucursales_Click);
            // 
            // btnVendedores
            // 
            this.btnVendedores.Location = new Point(370, 150);
            this.btnVendedores.Name = "btnVendedores";
            this.btnVendedores.Size = new Size(150, 50);
            this.btnVendedores.TabIndex = 6;
            this.btnVendedores.Text = "Gestión de Vendedores";
            this.btnVendedores.UseVisualStyleBackColor = true;
            this.btnVendedores.Click += new EventHandler(this.btnVendedores_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.Location = new Point(250, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(250, 32);
            this.lblTitulo.TabIndex = 7;
            this.lblTitulo.Text = "TechStore S.A. - Sistema de Gestión";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(720, 240);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnVendedores);
            this.Controls.Add(this.btnSucursales);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnCategorias);
            this.Controls.Add(this.btnProductos);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "TechStore - Sistema de Gestión de Ventas";
            this.ResumeLayout(false);
            this.PerformLayout();
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

