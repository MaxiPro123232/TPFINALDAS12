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
            _ventaController = new VentaController();
            _productoController = new ProductoController();
            _sucursalController = new SucursalController();
            _vendedorController = new VendedorController();
            _clienteController = new ClienteController();
            CargarCombos();
        }

        private void CargarCombos()
        {
            // Cargar Sucursales con opción "TODOS"
            cmbSucursal.DataSource = null;
            var sucursales = _sucursalController.ObtenerTodas();
            var sucursalesConTodos = new List<dynamic>
            {
                new { Id = -1, Nombre = "TODOS" }
            };
            sucursalesConTodos.AddRange(sucursales.Select(s => new { s.Id, s.Nombre } as dynamic));
            cmbSucursal.DataSource = sucursalesConTodos;
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "Id";
            cmbSucursal.SelectedIndex = 0; // Seleccionar "TODOS" por defecto

            // Cargar Vendedores con opción "TODOS"
            cmbVendedor.DataSource = null;
            var vendedores = _vendedorController.ObtenerTodos();
            var vendedoresConTodos = new List<dynamic>
            {
                new { Id = -1, Nombre = "TODOS" }
            };
            vendedoresConTodos.AddRange(vendedores.Select(v => new { v.Id, Nombre = v.Nombre } as dynamic));
            cmbVendedor.DataSource = vendedoresConTodos;
            cmbVendedor.DisplayMember = "Nombre";
            cmbVendedor.ValueMember = "Id";
            cmbVendedor.SelectedIndex = 0; // Seleccionar "TODOS" por defecto

            // Cargar Productos con opción "TODOS"
            cmbProducto.DataSource = null;
            var productos = _productoController.ObtenerTodos();
            var productosConTodos = new List<dynamic>
            {
                new { Id = -1, Nombre = "TODOS" }
            };
            productosConTodos.AddRange(productos.Select(p => new { p.Id, p.Nombre } as dynamic));
            cmbProducto.DataSource = productosConTodos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id";
            cmbProducto.SelectedIndex = 0; // Seleccionar "TODOS" por defecto

            // Cargar Clientes con opción "TODOS"
            cmbCliente.DataSource = null;
            var clientes = _clienteController.ObtenerTodos();
            var clientesConTodos = new List<dynamic>
            {
                new { Id = -1, Nombre = "TODOS" }
            };
            clientesConTodos.AddRange(clientes.Select(c => new { c.Id, Nombre = c.Nombre } as dynamic));
            cmbCliente.DataSource = clientesConTodos;
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "Id";
            cmbCliente.SelectedIndex = 0; // Seleccionar "TODOS" por defecto
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

            int selectedId = (int)cmbProducto.SelectedValue;
            List<Venta> ventas;
            string titulo;

            if (selectedId == -1) // TODOS
            {
                ventas = _ventaController.ObtenerTodas();
                titulo = "Ventas de Todos los Productos";
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
            }
            else
            {
                int productoId = selectedId;
                ventas = _ventaController.ObtenerVentasPorProducto(productoId);
                var producto = _productoController.ObtenerPorId(productoId);
                titulo = $"Ventas del Producto: {producto?.Nombre}";
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
            }

            lblTituloReporte.Text = titulo;
        }

        private void btnVentasPorSucursal_Click(object sender, EventArgs e)
        {
            if (cmbSucursal.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una sucursal.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedId = (int)cmbSucursal.SelectedValue;
            List<Venta> ventas;
            string titulo;

            if (selectedId == -1) // TODOS
            {
                ventas = _ventaController.ObtenerTodas();
                titulo = "Ventas de Todas las Sucursales";
            }
            else
            {
                int sucursalId = selectedId;
                ventas = _ventaController.ObtenerVentasPorSucursal(sucursalId);
                var sucursal = _sucursalController.ObtenerPorId(sucursalId);
                titulo = $"Ventas de la Sucursal: {sucursal?.Nombre}";
            }

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

            lblTituloReporte.Text = titulo;
        }

        private void btnVentasPorVendedor_Click(object sender, EventArgs e)
        {
            if (cmbVendedor.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un vendedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedId = (int)cmbVendedor.SelectedValue;
            List<Venta> ventas;
            string titulo;

            if (selectedId == -1) // TODOS
            {
                ventas = _ventaController.ObtenerTodas();
                titulo = "Ventas de Todos los Vendedores";
            }
            else
            {
                int vendedorId = selectedId;
                ventas = _ventaController.ObtenerVentasPorVendedor(vendedorId);
                var vendedor = _vendedorController.ObtenerPorId(vendedorId);
                titulo = $"Ventas del Vendedor: {vendedor?.Nombre}";
            }

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

            lblTituloReporte.Text = titulo;
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

            int selectedId = (int)cmbCliente.SelectedValue;
            
            if (selectedId == -1) // TODOS
            {
                var clientes = _clienteController.ObtenerTodos();
                dgvReportes.DataSource = null;
                dgvReportes.DataSource = clientes.Select(c => new
                {
                    Cliente = c.Nombre,
                    TipoCliente = c.TipoCliente.ToString(),
                    SaldoCuentaCorriente = c.SaldoCuentaCorriente
                }).ToList();

                lblTituloReporte.Text = "Estado de Cuenta Corriente - Todos los Clientes";
            }
            else
            {
                int clienteId = selectedId;
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
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}

