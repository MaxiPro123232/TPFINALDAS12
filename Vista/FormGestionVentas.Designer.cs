namespace TechStore.Vistas
{
    partial class FormGestionVentas
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
            cmbMetodoPago = new ComboBox();
            cmbSucursal = new ComboBox();
            cmbVendedor = new ComboBox();
            cmbCliente = new ComboBox();
            lblMetodoPago = new Label();
            lblSucursal = new Label();
            lblVendedor = new Label();
            lblCliente = new Label();
            groupBox2 = new GroupBox();
            btnAgregarProducto = new Button();
            txtDescuentoDetalle = new TextBox();
            txtCantidad = new TextBox();
            cmbProducto = new ComboBox();
            lblDescuentoDetalle = new Label();
            lblCantidad = new Label();
            lblProducto = new Label();
            groupBox3 = new GroupBox();
            btnEliminarDetalle = new Button();
            dgvDetalles = new DataGridView();
            groupBox4 = new GroupBox();
            lblTotal = new Label();
            lblDescuento = new Label();
            lblSubtotal = new Label();
            lblTotalLabel = new Label();
            lblDescuentoLabel = new Label();
            lblSubtotalLabel = new Label();
            btnProcesarVenta = new Button();
            btnNuevaVenta = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbMetodoPago);
            groupBox1.Controls.Add(cmbSucursal);
            groupBox1.Controls.Add(cmbVendedor);
            groupBox1.Controls.Add(cmbCliente);
            groupBox1.Controls.Add(lblMetodoPago);
            groupBox1.Controls.Add(lblSucursal);
            groupBox1.Controls.Add(lblVendedor);
            groupBox1.Controls.Add(lblCliente);
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(500, 150);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de la Venta";
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(120, 110);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(350, 23);
            cmbMetodoPago.TabIndex = 7;
            // 
            // cmbSucursal
            // 
            cmbSucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(120, 80);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(350, 23);
            cmbSucursal.TabIndex = 6;
            // 
            // cmbVendedor
            // 
            cmbVendedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVendedor.FormattingEnabled = true;
            cmbVendedor.Location = new Point(120, 50);
            cmbVendedor.Name = "cmbVendedor";
            cmbVendedor.Size = new Size(350, 23);
            cmbVendedor.TabIndex = 5;
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(120, 20);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(350, 23);
            cmbCliente.TabIndex = 4;
            cmbCliente.SelectionChangeCommitted += cmbCliente_SelectionChanged;
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Location = new Point(20, 113);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(98, 15);
            lblMetodoPago.TabIndex = 3;
            lblMetodoPago.Text = "Método de Pago:";
            // 
            // lblSucursal
            // 
            lblSucursal.AutoSize = true;
            lblSucursal.Location = new Point(20, 83);
            lblSucursal.Name = "lblSucursal";
            lblSucursal.Size = new Size(54, 15);
            lblSucursal.TabIndex = 2;
            lblSucursal.Text = "Sucursal:";
            // 
            // lblVendedor
            // 
            lblVendedor.AutoSize = true;
            lblVendedor.Location = new Point(20, 53);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(60, 15);
            lblVendedor.TabIndex = 1;
            lblVendedor.Text = "Vendedor:";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(20, 23);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(47, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAgregarProducto);
            groupBox2.Controls.Add(txtDescuentoDetalle);
            groupBox2.Controls.Add(txtCantidad);
            groupBox2.Controls.Add(cmbProducto);
            groupBox2.Controls.Add(lblDescuentoDetalle);
            groupBox2.Controls.Add(lblCantidad);
            groupBox2.Controls.Add(lblProducto);
            groupBox2.Location = new Point(540, 20);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(400, 164);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Agregar Producto";
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(20, 110);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(350, 30);
            btnAgregarProducto.TabIndex = 6;
            btnAgregarProducto.Text = "Agregar Producto";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // txtDescuentoDetalle
            // 
            txtDescuentoDetalle.Location = new Point(120, 80);
            txtDescuentoDetalle.Name = "txtDescuentoDetalle";
            txtDescuentoDetalle.Size = new Size(250, 23);
            txtDescuentoDetalle.TabIndex = 5;
            txtDescuentoDetalle.Text = "0";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(120, 50);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(250, 23);
            txtCantidad.TabIndex = 4;
            txtCantidad.Text = "1";
            // 
            // cmbProducto
            // 
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(120, 20);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(250, 23);
            cmbProducto.TabIndex = 3;
            // 
            // lblDescuentoDetalle
            // 
            lblDescuentoDetalle.AutoSize = true;
            lblDescuentoDetalle.Location = new Point(20, 83);
            lblDescuentoDetalle.Name = "lblDescuentoDetalle";
            lblDescuentoDetalle.Size = new Size(66, 15);
            lblDescuentoDetalle.TabIndex = 2;
            lblDescuentoDetalle.Text = "Descuento:";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(20, 53);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(58, 15);
            lblCantidad.TabIndex = 1;
            lblCantidad.Text = "Cantidad:";
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(20, 23);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(59, 15);
            lblProducto.TabIndex = 0;
            lblProducto.Text = "Producto:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnEliminarDetalle);
            groupBox3.Controls.Add(dgvDetalles);
            groupBox3.Location = new Point(20, 190);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(920, 250);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Detalles de la Venta";
            // 
            // btnEliminarDetalle
            // 
            btnEliminarDetalle.Location = new Point(20, 210);
            btnEliminarDetalle.Name = "btnEliminarDetalle";
            btnEliminarDetalle.Size = new Size(150, 30);
            btnEliminarDetalle.TabIndex = 1;
            btnEliminarDetalle.Text = "Eliminar Producto";
            btnEliminarDetalle.UseVisualStyleBackColor = true;
            btnEliminarDetalle.Click += btnEliminarDetalle_Click;
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(20, 20);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(880, 180);
            dgvDetalles.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lblTotal);
            groupBox4.Controls.Add(lblDescuento);
            groupBox4.Controls.Add(lblSubtotal);
            groupBox4.Controls.Add(lblTotalLabel);
            groupBox4.Controls.Add(lblDescuentoLabel);
            groupBox4.Controls.Add(lblSubtotalLabel);
            groupBox4.Location = new Point(20, 460);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(500, 120);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Totales";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(120, 80);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(41, 21);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "0.00";
            // 
            // lblDescuento
            // 
            lblDescuento.AutoSize = true;
            lblDescuento.Location = new Point(120, 50);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(28, 15);
            lblDescuento.TabIndex = 4;
            lblDescuento.Text = "0.00";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(120, 20);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(28, 15);
            lblSubtotal.TabIndex = 3;
            lblSubtotal.Text = "0.00";
            // 
            // lblTotalLabel
            // 
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalLabel.Location = new Point(20, 80);
            lblTotalLabel.Name = "lblTotalLabel";
            lblTotalLabel.Size = new Size(52, 21);
            lblTotalLabel.TabIndex = 2;
            lblTotalLabel.Text = "Total:";
            // 
            // lblDescuentoLabel
            // 
            lblDescuentoLabel.AutoSize = true;
            lblDescuentoLabel.Location = new Point(20, 50);
            lblDescuentoLabel.Name = "lblDescuentoLabel";
            lblDescuentoLabel.Size = new Size(66, 15);
            lblDescuentoLabel.TabIndex = 1;
            lblDescuentoLabel.Text = "Descuento:";
            // 
            // lblSubtotalLabel
            // 
            lblSubtotalLabel.AutoSize = true;
            lblSubtotalLabel.Location = new Point(20, 20);
            lblSubtotalLabel.Name = "lblSubtotalLabel";
            lblSubtotalLabel.Size = new Size(54, 15);
            lblSubtotalLabel.TabIndex = 0;
            lblSubtotalLabel.Text = "Subtotal:";
            // 
            // btnProcesarVenta
            // 
            btnProcesarVenta.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnProcesarVenta.Location = new Point(540, 460);
            btnProcesarVenta.Name = "btnProcesarVenta";
            btnProcesarVenta.Size = new Size(200, 60);
            btnProcesarVenta.TabIndex = 4;
            btnProcesarVenta.Text = "Procesar Venta";
            btnProcesarVenta.UseVisualStyleBackColor = true;
            btnProcesarVenta.Click += btnProcesarVenta_Click;
            // 
            // btnNuevaVenta
            // 
            btnNuevaVenta.Location = new Point(760, 460);
            btnNuevaVenta.Name = "btnNuevaVenta";
            btnNuevaVenta.Size = new Size(180, 60);
            btnNuevaVenta.TabIndex = 5;
            btnNuevaVenta.Text = "Nueva Venta";
            btnNuevaVenta.UseVisualStyleBackColor = true;
            btnNuevaVenta.Click += btnNuevaVenta_Click;
            // 
            // FormGestionVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 600);
            Controls.Add(btnNuevaVenta);
            Controls.Add(btnProcesarVenta);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormGestionVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Ventas";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        private GroupBox groupBox1;
        private ComboBox cmbMetodoPago;
        private ComboBox cmbSucursal;
        private ComboBox cmbVendedor;
        private ComboBox cmbCliente;
        private Label lblMetodoPago;
        private Label lblSucursal;
        private Label lblVendedor;
        private Label lblCliente;
        private GroupBox groupBox2;
        private Button btnAgregarProducto;
        private TextBox txtDescuentoDetalle;
        private TextBox txtCantidad;
        private ComboBox cmbProducto;
        private Label lblDescuentoDetalle;
        private Label lblCantidad;
        private Label lblProducto;
        private GroupBox groupBox3;
        private Button btnEliminarDetalle;
        private DataGridView dgvDetalles;
        private GroupBox groupBox4;
        private Label lblTotal;
        private Label lblDescuento;
        private Label lblSubtotal;
        private Label lblTotalLabel;
        private Label lblDescuentoLabel;
        private Label lblSubtotalLabel;
        private Button btnProcesarVenta;
        private Button btnNuevaVenta;
    }
}

