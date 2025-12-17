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
            groupBox1 = new GroupBox();
            btnCuentaCorriente = new Button();
            btnProductosMasVendidos = new Button();
            btnVentasPorVendedor = new Button();
            btnVentasPorSucursal = new Button();
            btnVentasPorProducto = new Button();
            btnVentasPorPeriodo = new Button();
            cmbCliente = new ComboBox();
            cmbVendedor = new ComboBox();
            cmbSucursal = new ComboBox();
            cmbProducto = new ComboBox();
            dtpFechaFin = new DateTimePicker();
            dtpFechaInicio = new DateTimePicker();
            lblCliente = new Label();
            lblVendedor = new Label();
            lblSucursal = new Label();
            lblProducto = new Label();
            lblFechaFin = new Label();
            lblFechaInicio = new Label();
            dgvReportes = new DataGridView();
            lblTituloReporte = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCuentaCorriente);
            groupBox1.Controls.Add(btnProductosMasVendidos);
            groupBox1.Controls.Add(btnVentasPorVendedor);
            groupBox1.Controls.Add(btnVentasPorSucursal);
            groupBox1.Controls.Add(btnVentasPorProducto);
            groupBox1.Controls.Add(btnVentasPorPeriodo);
            groupBox1.Controls.Add(cmbCliente);
            groupBox1.Controls.Add(cmbVendedor);
            groupBox1.Controls.Add(cmbSucursal);
            groupBox1.Controls.Add(cmbProducto);
            groupBox1.Controls.Add(dtpFechaFin);
            groupBox1.Controls.Add(dtpFechaInicio);
            groupBox1.Controls.Add(lblCliente);
            groupBox1.Controls.Add(lblVendedor);
            groupBox1.Controls.Add(lblSucursal);
            groupBox1.Controls.Add(lblProducto);
            groupBox1.Controls.Add(lblFechaFin);
            groupBox1.Controls.Add(lblFechaInicio);
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1169, 215);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros y Consultas";
            // 
            // btnCuentaCorriente
            // 
            btnCuentaCorriente.Location = new Point(996, 150);
            btnCuentaCorriente.Name = "btnCuentaCorriente";
            btnCuentaCorriente.Size = new Size(157, 30);
            btnCuentaCorriente.TabIndex = 16;
            btnCuentaCorriente.Text = "Cuenta Corriente";
            btnCuentaCorriente.UseVisualStyleBackColor = true;
            btnCuentaCorriente.Click += btnCuentaCorriente_Click;
            // 
            // btnProductosMasVendidos
            // 
            btnProductosMasVendidos.Location = new Point(818, 150);
            btnProductosMasVendidos.Name = "btnProductosMasVendidos";
            btnProductosMasVendidos.Size = new Size(154, 30);
            btnProductosMasVendidos.TabIndex = 15;
            btnProductosMasVendidos.Text = "Productos Más Vendidos";
            btnProductosMasVendidos.UseVisualStyleBackColor = true;
            btnProductosMasVendidos.Click += btnProductosMasVendidos_Click;
            // 
            // btnVentasPorVendedor
            // 
            btnVentasPorVendedor.Location = new Point(643, 150);
            btnVentasPorVendedor.Name = "btnVentasPorVendedor";
            btnVentasPorVendedor.Size = new Size(157, 30);
            btnVentasPorVendedor.TabIndex = 14;
            btnVentasPorVendedor.Text = "Ventas por Vendedor";
            btnVentasPorVendedor.UseVisualStyleBackColor = true;
            btnVentasPorVendedor.Click += btnVentasPorVendedor_Click;
            // 
            // btnVentasPorSucursal
            // 
            btnVentasPorSucursal.Location = new Point(480, 150);
            btnVentasPorSucursal.Name = "btnVentasPorSucursal";
            btnVentasPorSucursal.Size = new Size(141, 30);
            btnVentasPorSucursal.TabIndex = 13;
            btnVentasPorSucursal.Text = "Ventas por Sucursal";
            btnVentasPorSucursal.Click += btnVentasPorSucursal_Click;
            // 
            // btnVentasPorProducto
            // 
            btnVentasPorProducto.Location = new Point(243, 150);
            btnVentasPorProducto.Name = "btnVentasPorProducto";
            btnVentasPorProducto.Size = new Size(215, 30);
            btnVentasPorProducto.TabIndex = 12;
            btnVentasPorProducto.Text = "Ventas por Producto";
            btnVentasPorProducto.UseVisualStyleBackColor = true;
            btnVentasPorProducto.Click += btnVentasPorProducto_Click;
            // 
            // btnVentasPorPeriodo
            // 
            btnVentasPorPeriodo.Location = new Point(6, 150);
            btnVentasPorPeriodo.Name = "btnVentasPorPeriodo";
            btnVentasPorPeriodo.Size = new Size(217, 30);
            btnVentasPorPeriodo.TabIndex = 11;
            btnVentasPorPeriodo.Text = "Ventas por Período";
            btnVentasPorPeriodo.UseVisualStyleBackColor = true;
            btnVentasPorPeriodo.Click += btnVentasPorPeriodo_Click;
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(996, 110);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(157, 23);
            cmbCliente.TabIndex = 10;
            // 
            // cmbVendedor
            // 
            cmbVendedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVendedor.FormattingEnabled = true;
            cmbVendedor.Location = new Point(818, 108);
            cmbVendedor.Name = "cmbVendedor";
            cmbVendedor.Size = new Size(154, 23);
            cmbVendedor.TabIndex = 9;
            // 
            // cmbSucursal
            // 
            cmbSucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(643, 110);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(157, 23);
            cmbSucursal.TabIndex = 8;
            // 
            // cmbProducto
            // 
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(480, 108);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(141, 23);
            cmbProducto.TabIndex = 7;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Location = new Point(243, 110);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(215, 23);
            dtpFechaFin.TabIndex = 6;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(6, 110);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(217, 23);
            dtpFechaInicio.TabIndex = 5;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(996, 90);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(47, 15);
            lblCliente.TabIndex = 4;
            lblCliente.Text = "Cliente:";
            // 
            // lblVendedor
            // 
            lblVendedor.AutoSize = true;
            lblVendedor.Location = new Point(818, 90);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(60, 15);
            lblVendedor.TabIndex = 3;
            lblVendedor.Text = "Vendedor:";
            // 
            // lblSucursal
            // 
            lblSucursal.AutoSize = true;
            lblSucursal.Location = new Point(643, 90);
            lblSucursal.Name = "lblSucursal";
            lblSucursal.Size = new Size(54, 15);
            lblSucursal.TabIndex = 2;
            lblSucursal.Text = "Sucursal:";
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(480, 90);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(59, 15);
            lblProducto.TabIndex = 1;
            lblProducto.Text = "Producto:";
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(243, 90);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(60, 15);
            lblFechaFin.TabIndex = 0;
            lblFechaFin.Text = "Fecha Fin:";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(6, 90);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(73, 15);
            lblFechaInicio.TabIndex = 0;
            lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // dgvReportes
            // 
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.AllowUserToDeleteRows = false;
            dgvReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportes.Location = new Point(20, 280);
            dgvReportes.Name = "dgvReportes";
            dgvReportes.ReadOnly = true;
            dgvReportes.Size = new Size(1169, 350);
            dgvReportes.TabIndex = 1;
            // 
            // lblTituloReporte
            // 
            lblTituloReporte.AutoSize = true;
            lblTituloReporte.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTituloReporte.Location = new Point(20, 250);
            lblTituloReporte.Name = "lblTituloReporte";
            lblTituloReporte.Size = new Size(0, 21);
            lblTituloReporte.TabIndex = 2;
            // 
            // FormReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 650);
            Controls.Add(lblTituloReporte);
            Controls.Add(dgvReportes);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormReportes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reportes y Consultas";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            ResumeLayout(false);
            PerformLayout();
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

