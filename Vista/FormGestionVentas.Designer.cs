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
            this.groupBox1 = new GroupBox();
            this.cmbMetodoPago = new ComboBox();
            this.cmbSucursal = new ComboBox();
            this.cmbVendedor = new ComboBox();
            this.cmbCliente = new ComboBox();
            this.lblMetodoPago = new Label();
            this.lblSucursal = new Label();
            this.lblVendedor = new Label();
            this.lblCliente = new Label();
            this.groupBox2 = new GroupBox();
            this.btnAgregarProducto = new Button();
            this.txtDescuentoDetalle = new TextBox();
            this.txtCantidad = new TextBox();
            this.cmbProducto = new ComboBox();
            this.lblDescuentoDetalle = new Label();
            this.lblCantidad = new Label();
            this.lblProducto = new Label();
            this.groupBox3 = new GroupBox();
            this.btnEliminarDetalle = new Button();
            this.dgvDetalles = new DataGridView();
            this.groupBox4 = new GroupBox();
            this.lblTotal = new Label();
            this.lblDescuento = new Label();
            this.lblSubtotal = new Label();
            this.lblTotalLabel = new Label();
            this.lblDescuentoLabel = new Label();
            this.lblSubtotalLabel = new Label();
            this.btnProcesarVenta = new Button();
            this.btnNuevaVenta = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbMetodoPago);
            this.groupBox1.Controls.Add(this.cmbSucursal);
            this.groupBox1.Controls.Add(this.cmbVendedor);
            this.groupBox1.Controls.Add(this.cmbCliente);
            this.groupBox1.Controls.Add(this.lblMetodoPago);
            this.groupBox1.Controls.Add(this.lblSucursal);
            this.groupBox1.Controls.Add(this.lblVendedor);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Location = new Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(500, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Venta";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new Point(120, 110);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new Size(350, 23);
            this.cmbMetodoPago.TabIndex = 7;
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new Point(120, 80);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new Size(350, 23);
            this.cmbSucursal.TabIndex = 6;
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.Location = new Point(120, 50);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new Size(350, 23);
            this.cmbVendedor.TabIndex = 5;
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new Point(120, 20);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new Size(350, 23);
            this.cmbCliente.TabIndex = 4;
            this.cmbCliente.SelectionChangeCommitted += new EventHandler(this.cmbCliente_SelectionChanged);
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new Point(20, 113);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new Size(88, 15);
            this.lblMetodoPago.TabIndex = 3;
            this.lblMetodoPago.Text = "Método de Pago:";
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new Point(20, 83);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new Size(57, 15);
            this.lblSucursal.TabIndex = 2;
            this.lblSucursal.Text = "Sucursal:";
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new Point(20, 53);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new Size(60, 15);
            this.lblVendedor.TabIndex = 1;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new Point(20, 23);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new Size(47, 15);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAgregarProducto);
            this.groupBox2.Controls.Add(this.txtDescuentoDetalle);
            this.groupBox2.Controls.Add(this.txtCantidad);
            this.groupBox2.Controls.Add(this.cmbProducto);
            this.groupBox2.Controls.Add(this.lblDescuentoDetalle);
            this.groupBox2.Controls.Add(this.lblCantidad);
            this.groupBox2.Controls.Add(this.lblProducto);
            this.groupBox2.Location = new Point(540, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(400, 150);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agregar Producto";
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new Point(20, 110);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new Size(350, 30);
            this.btnAgregarProducto.TabIndex = 6;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new EventHandler(this.btnAgregarProducto_Click);
            // 
            // txtDescuentoDetalle
            // 
            this.txtDescuentoDetalle.Location = new Point(120, 80);
            this.txtDescuentoDetalle.Name = "txtDescuentoDetalle";
            this.txtDescuentoDetalle.Size = new Size(250, 23);
            this.txtDescuentoDetalle.TabIndex = 5;
            this.txtDescuentoDetalle.Text = "0";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new Point(120, 50);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new Size(250, 23);
            this.txtCantidad.TabIndex = 4;
            this.txtCantidad.Text = "1";
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new Point(120, 20);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new Size(250, 23);
            this.cmbProducto.TabIndex = 3;
            // 
            // lblDescuentoDetalle
            // 
            this.lblDescuentoDetalle.AutoSize = true;
            this.lblDescuentoDetalle.Location = new Point(20, 83);
            this.lblDescuentoDetalle.Name = "lblDescuentoDetalle";
            this.lblDescuentoDetalle.Size = new Size(65, 15);
            this.lblDescuentoDetalle.TabIndex = 2;
            this.lblDescuentoDetalle.Text = "Descuento:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new Point(20, 53);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new Size(58, 15);
            this.lblCantidad.TabIndex = 1;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new Point(20, 23);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new Size(59, 15);
            this.lblProducto.TabIndex = 0;
            this.lblProducto.Text = "Producto:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnEliminarDetalle);
            this.groupBox3.Controls.Add(this.dgvDetalles);
            this.groupBox3.Location = new Point(20, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(920, 250);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detalles de la Venta";
            // 
            // btnEliminarDetalle
            // 
            this.btnEliminarDetalle.Location = new Point(20, 210);
            this.btnEliminarDetalle.Name = "btnEliminarDetalle";
            this.btnEliminarDetalle.Size = new Size(150, 30);
            this.btnEliminarDetalle.TabIndex = 1;
            this.btnEliminarDetalle.Text = "Eliminar Producto";
            this.btnEliminarDetalle.UseVisualStyleBackColor = true;
            this.btnEliminarDetalle.Click += new EventHandler(this.btnEliminarDetalle_Click);
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Location = new Point(20, 20);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new Size(880, 180);
            this.dgvDetalles.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTotal);
            this.groupBox4.Controls.Add(this.lblDescuento);
            this.groupBox4.Controls.Add(this.lblSubtotal);
            this.groupBox4.Controls.Add(this.lblTotalLabel);
            this.groupBox4.Controls.Add(this.lblDescuentoLabel);
            this.groupBox4.Controls.Add(this.lblSubtotalLabel);
            this.groupBox4.Location = new Point(20, 460);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(500, 120);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Totales";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTotal.Location = new Point(120, 80);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new Size(38, 21);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "0.00";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new Point(120, 50);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new Size(28, 15);
            this.lblDescuento.TabIndex = 4;
            this.lblDescuento.Text = "0.00";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new Point(120, 20);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new Size(28, 15);
            this.lblSubtotal.TabIndex = 3;
            this.lblSubtotal.Text = "0.00";
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTotalLabel.Location = new Point(20, 80);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new Size(49, 21);
            this.lblTotalLabel.TabIndex = 2;
            this.lblTotalLabel.Text = "Total:";
            // 
            // lblDescuentoLabel
            // 
            this.lblDescuentoLabel.AutoSize = true;
            this.lblDescuentoLabel.Location = new Point(20, 50);
            this.lblDescuentoLabel.Name = "lblDescuentoLabel";
            this.lblDescuentoLabel.Size = new Size(65, 15);
            this.lblDescuentoLabel.TabIndex = 1;
            this.lblDescuentoLabel.Text = "Descuento:";
            // 
            // lblSubtotalLabel
            // 
            this.lblSubtotalLabel.AutoSize = true;
            this.lblSubtotalLabel.Location = new Point(20, 20);
            this.lblSubtotalLabel.Name = "lblSubtotalLabel";
            this.lblSubtotalLabel.Size = new Size(57, 15);
            this.lblSubtotalLabel.TabIndex = 0;
            this.lblSubtotalLabel.Text = "Subtotal:";
            // 
            // btnProcesarVenta
            // 
            this.btnProcesarVenta.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnProcesarVenta.Location = new Point(540, 460);
            this.btnProcesarVenta.Name = "btnProcesarVenta";
            this.btnProcesarVenta.Size = new Size(200, 60);
            this.btnProcesarVenta.TabIndex = 4;
            this.btnProcesarVenta.Text = "Procesar Venta";
            this.btnProcesarVenta.UseVisualStyleBackColor = true;
            this.btnProcesarVenta.Click += new EventHandler(this.btnProcesarVenta_Click);
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.Location = new Point(760, 460);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new Size(180, 60);
            this.btnNuevaVenta.TabIndex = 5;
            this.btnNuevaVenta.Text = "Nueva Venta";
            this.btnNuevaVenta.UseVisualStyleBackColor = true;
            this.btnNuevaVenta.Click += new EventHandler(this.btnNuevaVenta_Click);
            // 
            // FormGestionVentas
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(960, 600);
            this.Controls.Add(this.btnNuevaVenta);
            this.Controls.Add(this.btnProcesarVenta);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGestionVentas";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestión de Ventas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
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

