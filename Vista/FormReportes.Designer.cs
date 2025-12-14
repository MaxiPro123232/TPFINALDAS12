namespace TechStore.Vistas
{
    partial class FormReportes
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
            this.groupBox1 = new GroupBox();
            this.btnCuentaCorriente = new Button();
            this.btnProductosMasVendidos = new Button();
            this.btnVentasPorVendedor = new Button();
            this.btnVentasPorSucursal = new Button();
            this.btnVentasPorProducto = new Button();
            this.btnVentasPorPeriodo = new Button();
            this.cmbCliente = new ComboBox();
            this.cmbVendedor = new ComboBox();
            this.cmbSucursal = new ComboBox();
            this.cmbProducto = new ComboBox();
            this.dtpFechaFin = new DateTimePicker();
            this.dtpFechaInicio = new DateTimePicker();
            this.lblCliente = new Label();
            this.lblVendedor = new Label();
            this.lblSucursal = new Label();
            this.lblProducto = new Label();
            this.lblFechaFin = new Label();
            this.lblFechaInicio = new Label();
            this.dgvReportes = new DataGridView();
            this.lblTituloReporte = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCuentaCorriente);
            this.groupBox1.Controls.Add(this.btnProductosMasVendidos);
            this.groupBox1.Controls.Add(this.btnVentasPorVendedor);
            this.groupBox1.Controls.Add(this.btnVentasPorSucursal);
            this.groupBox1.Controls.Add(this.btnVentasPorProducto);
            this.groupBox1.Controls.Add(this.btnVentasPorPeriodo);
            this.groupBox1.Controls.Add(this.cmbCliente);
            this.groupBox1.Controls.Add(this.cmbVendedor);
            this.groupBox1.Controls.Add(this.cmbSucursal);
            this.groupBox1.Controls.Add(this.cmbProducto);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Controls.Add(this.lblVendedor);
            this.groupBox1.Controls.Add(this.lblSucursal);
            this.groupBox1.Controls.Add(this.lblProducto);
            this.groupBox1.Controls.Add(this.lblFechaFin);
            this.groupBox1.Controls.Add(this.lblFechaInicio);
            this.groupBox1.Location = new Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(900, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros y Consultas";
            // 
            // btnCuentaCorriente
            // 
            this.btnCuentaCorriente.Location = new Point(750, 150);
            this.btnCuentaCorriente.Name = "btnCuentaCorriente";
            this.btnCuentaCorriente.Size = new Size(130, 30);
            this.btnCuentaCorriente.TabIndex = 16;
            this.btnCuentaCorriente.Text = "Cuenta Corriente";
            this.btnCuentaCorriente.UseVisualStyleBackColor = true;
            this.btnCuentaCorriente.Click += new EventHandler(this.btnCuentaCorriente_Click);
            // 
            // btnProductosMasVendidos
            // 
            this.btnProductosMasVendidos.Location = new Point(600, 150);
            this.btnProductosMasVendidos.Name = "btnProductosMasVendidos";
            this.btnProductosMasVendidos.Size = new Size(130, 30);
            this.btnProductosMasVendidos.TabIndex = 15;
            this.btnProductosMasVendidos.Text = "Productos Más Vendidos";
            this.btnProductosMasVendidos.UseVisualStyleBackColor = true;
            this.btnProductosMasVendidos.Click += new EventHandler(this.btnProductosMasVendidos_Click);
            // 
            // btnVentasPorVendedor
            // 
            this.btnVentasPorVendedor.Location = new Point(450, 150);
            this.btnVentasPorVendedor.Name = "btnVentasPorVendedor";
            this.btnVentasPorVendedor.Size = new Size(130, 30);
            this.btnVentasPorVendedor.TabIndex = 14;
            this.btnVentasPorVendedor.Text = "Ventas por Vendedor";
            this.btnVentasPorVendedor.UseVisualStyleBackColor = true;
            this.btnVentasPorVendedor.Click += new EventHandler(this.btnVentasPorVendedor_Click);
            // 
            // btnVentasPorSucursal
            // 
            this.btnVentasPorSucursal.Location = new Point(300, 150);
            this.btnVentasPorSucursal.Name = "btnVentasPorSucursal";
            this.btnVentasPorSucursal.Size = new Size(130, 30);
            this.btnVentasPorSucursal.TabIndex = 13;
            this.btnVentasPorSucursal.Text = "Ventas por Sucursal";
            this.btnVentasPorSucursal.Click += new EventHandler(this.btnVentasPorSucursal_Click);
            // 
            // btnVentasPorProducto
            // 
            this.btnVentasPorProducto.Location = new Point(150, 150);
            this.btnVentasPorProducto.Name = "btnVentasPorProducto";
            this.btnVentasPorProducto.Size = new Size(130, 30);
            this.btnVentasPorProducto.TabIndex = 12;
            this.btnVentasPorProducto.Text = "Ventas por Producto";
            this.btnVentasPorProducto.UseVisualStyleBackColor = true;
            this.btnVentasPorProducto.Click += new EventHandler(this.btnVentasPorProducto_Click);
            // 
            // btnVentasPorPeriodo
            // 
            this.btnVentasPorPeriodo.Location = new Point(20, 150);
            this.btnVentasPorPeriodo.Name = "btnVentasPorPeriodo";
            this.btnVentasPorPeriodo.Size = new Size(110, 30);
            this.btnVentasPorPeriodo.TabIndex = 11;
            this.btnVentasPorPeriodo.Text = "Ventas por Período";
            this.btnVentasPorPeriodo.UseVisualStyleBackColor = true;
            this.btnVentasPorPeriodo.Click += new EventHandler(this.btnVentasPorPeriodo_Click);
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new Point(750, 110);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new Size(130, 23);
            this.cmbCliente.TabIndex = 10;
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.Location = new Point(600, 110);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new Size(130, 23);
            this.cmbVendedor.TabIndex = 9;
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new Point(450, 110);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new Size(130, 23);
            this.cmbSucursal.TabIndex = 8;
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new Point(300, 110);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new Size(130, 23);
            this.cmbProducto.TabIndex = 7;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new Point(150, 110);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new Size(130, 23);
            this.dtpFechaFin.TabIndex = 6;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new Point(20, 110);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new Size(110, 23);
            this.dtpFechaInicio.TabIndex = 5;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new Point(750, 90);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new Size(47, 15);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new Point(600, 90);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new Size(60, 15);
            this.lblVendedor.TabIndex = 3;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new Point(450, 90);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new Size(57, 15);
            this.lblSucursal.TabIndex = 2;
            this.lblSucursal.Text = "Sucursal:";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new Point(300, 90);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new Size(59, 15);
            this.lblProducto.TabIndex = 1;
            this.lblProducto.Text = "Producto:";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new Point(150, 90);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new Size(60, 15);
            this.lblFechaFin.TabIndex = 0;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new Point(20, 90);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new Size(75, 15);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // dgvReportes
            // 
            this.dgvReportes.AllowUserToAddRows = false;
            this.dgvReportes.AllowUserToDeleteRows = false;
            this.dgvReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Location = new Point(20, 280);
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.ReadOnly = true;
            this.dgvReportes.Size = new Size(900, 350);
            this.dgvReportes.TabIndex = 1;
            // 
            // lblTituloReporte
            // 
            this.lblTituloReporte.AutoSize = true;
            this.lblTituloReporte.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTituloReporte.Location = new Point(20, 250);
            this.lblTituloReporte.Name = "lblTituloReporte";
            this.lblTituloReporte.Size = new Size(0, 21);
            this.lblTituloReporte.TabIndex = 2;
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(940, 650);
            this.Controls.Add(this.lblTituloReporte);
            this.Controls.Add(this.dgvReportes);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormReportes";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Reportes y Consultas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private GroupBox groupBox1;
        private Button btnCuentaCorriente;
        private Button btnProductosMasVendidos;
        private Button btnVentasPorVendedor;
        private Button btnVentasPorSucursal;
        private Button btnVentasPorProducto;
        private Button btnVentasPorPeriodo;
        private ComboBox cmbCliente;
        private ComboBox cmbVendedor;
        private ComboBox cmbSucursal;
        private ComboBox cmbProducto;
        private DateTimePicker dtpFechaFin;
        private DateTimePicker dtpFechaInicio;
        private Label lblCliente;
        private Label lblVendedor;
        private Label lblSucursal;
        private Label lblProducto;
        private Label lblFechaFin;
        private Label lblFechaInicio;
        private DataGridView dgvReportes;
        private Label lblTituloReporte;
    }
}

