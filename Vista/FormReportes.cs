using TechStore.Controladores;
using TechStore.Entidades;
using TechStore.Modelo;

namespace TechStore.Vistas
{
    public partial class FormReportes : Form
    {
        private TechStoreDbContext _context;
        private VentaController _ventaController;
        private ProductoController _productoController;
        private SucursalController _sucursalController;
        private VendedorController _vendedorController;
        private ClienteController _clienteController;

        public FormReportes()
        {
            InitializeComponent();
            _context = new TechStoreDbContext();
            _ventaController = new VentaController(_context);
            _productoController = new ProductoController(_context);
            _sucursalController = new SucursalController(_context);
            _vendedorController = new VendedorController(_context);
            _clienteController = new ClienteController(_context);
            CargarCombos();
        }

        private void CargarCombos()
        {
            cmbSucursal.DataSource = null;
            cmbSucursal.DataSource = _sucursalController.ObtenerTodas();
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "Id";

            cmbVendedor.DataSource = null;
            cmbVendedor.DataSource = _vendedorController.ObtenerTodos();
            cmbVendedor.DisplayMember = "Nombre";
            cmbVendedor.ValueMember = "Id";

            cmbProducto.DataSource = null;
            cmbProducto.DataSource = _productoController.ObtenerTodos();
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id";

            cmbCliente.DataSource = null;
            cmbCliente.DataSource = _clienteController.ObtenerTodos();
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "Id";
        }

        private void btnVentasPorPeriodo_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1);

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio debe ser menor o igual a la fecha de fin.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ventas = _ventaController.ObtenerVentasPorPeriodo(fechaInicio, fechaFin);
            dgvReportes.DataSource = null;
            dgvReportes.DataSource = ventas.Select(v => new
            {
                NumeroFactura = v.NumeroFactura,
                Fecha = v.Fecha,
                Cliente = v.Cliente.Nombre,
                Vendedor = v.Vendedor.Nombre,
                Sucursal = v.Sucursal.Nombre,
                MetodoPago = v.MetodoPago.ToString(),
                Subtotal = v.Subtotal,
                Descuento = v.Descuento,
                Total = v.Total
            }).ToList();

            lblTituloReporte.Text = $"Ventas del Período: {fechaInicio:dd/MM/yyyy} - {fechaFin:dd/MM/yyyy}";
        }

        private void btnVentasPorProducto_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productoId = (int)cmbProducto.SelectedValue;
            var ventas = _ventaController.ObtenerVentasPorProducto(productoId);
            var producto = _productoController.ObtenerPorId(productoId);

            dgvReportes.DataSource = null;
            dgvReportes.DataSource = ventas.Select(v => new
            {
                NumeroFactura = v.NumeroFactura,
                Fecha = v.Fecha,
                Cliente = v.Cliente.Nombre,
                Vendedor = v.Vendedor.Nombre,
                Sucursal = v.Sucursal.Nombre,
                Cantidad = v.DetalleVentas.First(d => d.ProductoId == productoId).Cantidad,
                Total = v.DetalleVentas.First(d => d.ProductoId == productoId).Subtotal
            }).ToList();

            lblTituloReporte.Text = $"Ventas del Producto: {producto?.Nombre}";
        }

        private void btnVentasPorSucursal_Click(object sender, EventArgs e)
        {
            if (cmbSucursal.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una sucursal.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sucursalId = (int)cmbSucursal.SelectedValue;
            var ventas = _ventaController.ObtenerVentasPorSucursal(sucursalId);
            var sucursal = _sucursalController.ObtenerPorId(sucursalId);

            dgvReportes.DataSource = null;
            dgvReportes.DataSource = ventas.Select(v => new
            {
                NumeroFactura = v.NumeroFactura,
                Fecha = v.Fecha,
                Cliente = v.Cliente.Nombre,
                Vendedor = v.Vendedor.Nombre,
                MetodoPago = v.MetodoPago.ToString(),
                Subtotal = v.Subtotal,
                Descuento = v.Descuento,
                Total = v.Total
            }).ToList();

            lblTituloReporte.Text = $"Ventas de la Sucursal: {sucursal?.Nombre}";
        }

        private void btnVentasPorVendedor_Click(object sender, EventArgs e)
        {
            if (cmbVendedor.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un vendedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int vendedorId = (int)cmbVendedor.SelectedValue;
            var ventas = _ventaController.ObtenerVentasPorVendedor(vendedorId);
            var vendedor = _vendedorController.ObtenerPorId(vendedorId);

            dgvReportes.DataSource = null;
            dgvReportes.DataSource = ventas.Select(v => new
            {
                NumeroFactura = v.NumeroFactura,
                Fecha = v.Fecha,
                Cliente = v.Cliente.Nombre,
                Sucursal = v.Sucursal.Nombre,
                MetodoPago = v.MetodoPago.ToString(),
                Subtotal = v.Subtotal,
                Descuento = v.Descuento,
                Total = v.Total
            }).ToList();

            lblTituloReporte.Text = $"Ventas del Vendedor: {vendedor?.Nombre}";
        }

        private void btnProductosMasVendidos_Click(object sender, EventArgs e)
        {
            var productos = _ventaController.ObtenerProductosMasVendidos(10);
            dgvReportes.DataSource = null;
            dgvReportes.DataSource = productos;
            lblTituloReporte.Text = "Top 10 Productos Más Vendidos";
        }

        private void btnCuentaCorriente_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clienteId = (int)cmbCliente.SelectedValue;
            var cliente = _clienteController.ObtenerPorId(clienteId);
            decimal saldo = _clienteController.ObtenerSaldoCuentaCorriente(clienteId);

            dgvReportes.DataSource = null;
            dgvReportes.DataSource = new[]
            {
                new
                {
                    Cliente = cliente?.Nombre,
                    TipoCliente = cliente?.TipoCliente.ToString(),
                    SaldoCuentaCorriente = saldo
                }
            }.ToList();

            lblTituloReporte.Text = $"Estado de Cuenta Corriente - {cliente?.Nombre}";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}

