using TechStore.Controladores;
using TechStore.Entidades;
using TechStore.Modelo;

namespace TechStore.Vistas
{
    public partial class FormGestionVentas : Form
    {
        private TechStoreDbContext _context;
        private VentaController _ventaController;
        private ClienteController _clienteController;
        private ProductoController _productoController;
        private VendedorController _vendedorController;
        private SucursalController _sucursalController;
        private List<DetalleVenta> _detallesVenta;
        private Cliente? _clienteSeleccionado;

        public FormGestionVentas()
        {
            InitializeComponent();
            _context = new TechStoreDbContext();
            _ventaController = new VentaController();
            _clienteController = new ClienteController();
            _productoController = new ProductoController();
            _vendedorController = new VendedorController();
            _sucursalController = new SucursalController();
            _detallesVenta = new List<DetalleVenta>();
            CargarCombos();
            LimpiarVenta();
        }

        private void CargarCombos()
        {
            cmbCliente.DataSource = null;
            cmbCliente.DataSource = _clienteController.ObtenerTodos();
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "Id";

            cmbVendedor.DataSource = null;
            cmbVendedor.DataSource = _vendedorController.ObtenerTodos();
            cmbVendedor.DisplayMember = "Nombre";
            cmbVendedor.ValueMember = "Id";

            cmbSucursal.DataSource = null;
            cmbSucursal.DataSource = _sucursalController.ObtenerTodas();
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "Id";

            cmbProducto.DataSource = null;
            cmbProducto.DataSource = _productoController.ObtenerTodos();
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id";

            cmbMetodoPago.DataSource = Enum.GetValues(typeof(MetodoPago));
        }

        private void LimpiarVenta()
        {
            _detallesVenta.Clear();
            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = _detallesVenta;
            txtCantidad.Text = "1";
            txtDescuentoDetalle.Text = "0";
            lblSubtotal.Text = "0.00";
            lblDescuento.Text = "0.00";
            lblTotal.Text = "0.00";
            cmbCliente.SelectedIndex = -1;
            cmbVendedor.SelectedIndex = -1;
            cmbSucursal.SelectedIndex = -1;
            cmbProducto.SelectedIndex = -1;
            cmbMetodoPago.SelectedIndex = 0;
            _clienteSeleccionado = null;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtDescuentoDetalle.Text, out decimal descuento) || descuento < 0)
            {
                MessageBox.Show("El descuento debe ser un número mayor o igual a cero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productoId = (int)cmbProducto.SelectedValue;
            var producto = _productoController.ObtenerPorId(productoId);

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (producto.Stock < cantidad)
            {
                MessageBox.Show($"Stock insuficiente. Disponible: {producto.Stock}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var detalle = new DetalleVenta
            {
                ProductoId = productoId,
                Cantidad = cantidad,
                PrecioUnitario = producto.Precio,
                Descuento = descuento,
                Subtotal = (producto.Precio * cantidad) - descuento
            };

            _detallesVenta.Add(detalle);
            ActualizarGridDetalles();
            CalcularTotales();
            txtCantidad.Text = "1";
            txtDescuentoDetalle.Text = "0";
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.SelectedRows.Count > 0)
            {
                int index = dgvDetalles.SelectedRows[0].Index;
                _detallesVenta.RemoveAt(index);
                ActualizarGridDetalles();
                CalcularTotales();
            }
        }

        private void ActualizarGridDetalles()
        {
            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = _detallesVenta.Select(d => new
            {
                Producto = _productoController.ObtenerPorId(d.ProductoId)?.Nombre ?? "",
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario,
                Descuento = d.Descuento,
                Subtotal = d.Subtotal
            }).ToList();
        }

        // Calcula subtotal, descuento del cliente y total de la venta. Actualiza los labels correspondientes.
        private void CalcularTotales()
        {
            decimal subtotal = _detallesVenta.Sum(d => d.Subtotal);
            decimal descuentoCliente = 0;

            if (_clienteSeleccionado != null)
            {
                descuentoCliente = subtotal * (_clienteSeleccionado.Descuento / 100);
            }

            decimal total = subtotal - descuentoCliente;

            lblSubtotal.Text = subtotal.ToString("N2");
            lblDescuento.Text = descuentoCliente.ToString("N2");
            lblTotal.Text = total.ToString("N2");
        }

        private void cmbCliente_SelectionChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue != null)
            {
                int clienteId = (int)cmbCliente.SelectedValue;
                _clienteSeleccionado = _clienteController.ObtenerPorId(clienteId);
                CalcularTotales();
            }
            else
            {
                _clienteSeleccionado = null;
                CalcularTotales();
            }
        }

        // Procesa la venta completa: valida datos, crea la venta y sus detalles, actualiza stock. Muestra mensaje de éxito o error.
        private void btnProcesarVenta_Click(object sender, EventArgs e)
        {
            if (!ValidarVenta())
                return;

            if (_detallesVenta.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var venta = new Venta
            {
                ClienteId = (int)cmbCliente.SelectedValue,
                VendedorId = (int)cmbVendedor.SelectedValue,
                SucursalId = (int)cmbSucursal.SelectedValue,
                MetodoPago = (MetodoPago)cmbMetodoPago.SelectedValue,
                Fecha = DateTime.Now
            };

            if (_ventaController.ProcesarVenta(venta, _detallesVenta))
            {
                MessageBox.Show($"Venta procesada exitosamente.\nNúmero de Factura: {venta.NumeroFactura}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarVenta();
            }
            else
            {
                MessageBox.Show("Error al procesar la venta. Verifique el stock de los productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarVenta()
        {
            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbVendedor.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un vendedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbSucursal.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una sucursal.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            LimpiarVenta();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}

