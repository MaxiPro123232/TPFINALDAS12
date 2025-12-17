using TechStore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Modelo
{
    public class RepositorioVenta
    {
        private readonly TechStoreDbContext _context;
        private readonly RepositorioProducto _repositorioProducto;
        private readonly RepositorioCliente _repositorioCliente;

        public RepositorioVenta()
        {
            _context = new TechStoreDbContext();
            _repositorioProducto = new RepositorioProducto();
            _repositorioCliente = new RepositorioCliente();
        }

        public List<Venta> ListarVentas()
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor)
                .Include(v => v.Sucursal)
                .Include(v => v.DetalleVentas)
                    .ThenInclude(d => d.Producto)
                .AsNoTracking()
                .OrderByDescending(v => v.Fecha)
                .ToList();
        }

        public void AgregarVenta(Venta venta)
        {
            _context.Ventas.Add(venta);
            _context.SaveChanges();
        }

        public Venta BuscarVentaPorId(int ventaId)
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor)
                .Include(v => v.Sucursal)
                .Include(v => v.DetalleVentas)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefault(v => v.Id == ventaId);
        }

        public string GenerarNumeroFactura()
        {
            var ultimaVenta = _context.Ventas
                .OrderByDescending(v => v.Id)
                .FirstOrDefault();

            int siguienteNumero = 1;
            if (ultimaVenta != null && !string.IsNullOrEmpty(ultimaVenta.NumeroFactura))
            {
                var partes = ultimaVenta.NumeroFactura.Split('-');
                if (partes.Length > 0 && int.TryParse(partes[^1], out int numero))
                {
                    siguienteNumero = numero + 1;
                }
            }

            return $"FAC-{DateTime.Now:yyyyMMdd}-{siguienteNumero:D6}";
        }

        public bool ProcesarVenta(Venta venta, List<DetalleVenta> detalles)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // Validar stock de productos
                foreach (var detalle in detalles)
                {
                    var producto = _repositorioProducto.BuscarProductoPorId(detalle.ProductoId);
                    if (producto == null || producto.Stock < detalle.Cantidad)
                    {
                        transaction.Rollback();
                        return false; // Stock insuficiente
                    }
                }

                // Obtener cliente para aplicar descuento
                var cliente = _repositorioCliente.BuscarClientePorId(venta.ClienteId);
                if (cliente == null)
                {
                    transaction.Rollback();
                    return false;
                }

                // Calcular subtotales y aplicar descuentos
                decimal subtotal = 0;
                foreach (var detalle in detalles)
                {
                    var producto = _repositorioProducto.BuscarProductoPorId(detalle.ProductoId);
                    detalle.PrecioUnitario = producto!.Precio;
                    detalle.Subtotal = detalle.PrecioUnitario * detalle.Cantidad - detalle.Descuento;
                    subtotal += detalle.Subtotal;
                }

                // Aplicar descuento del cliente
                decimal descuentoTotal = subtotal * (cliente.Descuento / 100);
                venta.Subtotal = subtotal;
                venta.Descuento = descuentoTotal;
                venta.Total = subtotal - descuentoTotal;

                // Generar número de factura si no existe
                if (string.IsNullOrEmpty(venta.NumeroFactura))
                {
                    venta.NumeroFactura = GenerarNumeroFactura();
                }

                // Guardar venta
                _context.Ventas.Add(venta);
                _context.SaveChanges();

                // Guardar detalles
                foreach (var detalle in detalles)
                {
                    detalle.VentaId = venta.Id;
                    _context.DetalleVentas.Add(detalle);
                }
                _context.SaveChanges();

                // Actualizar stock de productos
                foreach (var detalle in detalles)
                {
                    if (!_repositorioProducto.ActualizarStock(detalle.ProductoId, -detalle.Cantidad))
                    {
                        transaction.Rollback();
                        return false;
                    }
                }

                // Si es cuenta corriente, actualizar saldo del cliente
                if (venta.MetodoPago == MetodoPago.Transferencia && venta.Total > 0)
                {
                    _repositorioCliente.ActualizarSaldoCuentaCorriente(venta.ClienteId, venta.Total);
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        public List<Venta> ListarVentasPorPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor)
                .Include(v => v.Sucursal)
                .Include(v => v.DetalleVentas)
                    .ThenInclude(d => d.Producto)
                .Where(v => v.Fecha >= fechaInicio && v.Fecha <= fechaFin)
                .AsNoTracking()
                .OrderByDescending(v => v.Fecha)
                .ToList();
        }

        public List<Venta> ListarVentasPorProducto(int productoId)
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor)
                .Include(v => v.Sucursal)
                .Include(v => v.DetalleVentas)
                    .ThenInclude(d => d.Producto)
                .Where(v => v.DetalleVentas.Any(d => d.ProductoId == productoId))
                .AsNoTracking()
                .OrderByDescending(v => v.Fecha)
                .ToList();
        }

        public List<Venta> ListarVentasPorSucursal(int sucursalId)
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor)
                .Include(v => v.Sucursal)
                .Include(v => v.DetalleVentas)
                    .ThenInclude(d => d.Producto)
                .Where(v => v.SucursalId == sucursalId)
                .AsNoTracking()
                .OrderByDescending(v => v.Fecha)
                .ToList();
        }

        public List<Venta> ListarVentasPorVendedor(int vendedorId)
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor)
                .Include(v => v.Sucursal)
                .Include(v => v.DetalleVentas)
                    .ThenInclude(d => d.Producto)
                .Where(v => v.VendedorId == vendedorId)
                .AsNoTracking()
                .OrderByDescending(v => v.Fecha)
                .ToList();
        }

        public List<dynamic> ObtenerProductosMasVendidos(int? top = 10)
        {
            return _context.DetalleVentas
                .Include(d => d.Producto)
                .AsNoTracking()
                .GroupBy(d => new { d.ProductoId, d.Producto.Nombre })
                .Select(g => new
                {
                    ProductoId = g.Key.ProductoId,
                    Nombre = g.Key.Nombre,
                    CantidadVendida = g.Sum(d => d.Cantidad),
                    TotalVendido = g.Sum(d => d.Subtotal)
                })
                .OrderByDescending(x => x.CantidadVendida)
                .Take(top ?? 10)
                .ToList<dynamic>();
        }
    }
}

