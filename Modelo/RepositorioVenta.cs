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

        // Retorna todas las ventas con sus relaciones cargadas, ordenadas por fecha descendente. No modifica BD.
        public List<Venta> ListarVentas()
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor)
                .Include(v => v.Sucursal)
                .Include(v => v.DetalleVentas)
                    // ThenInclude: carga relaciones anidadas (trae el Producto dentro de cada DetalleVenta).
                    .ThenInclude(d => d.Producto)
                .AsNoTracking()
                // OrderByDescending: ordena de mayor a menor (más recientes primero).
                .OrderByDescending(v => v.Fecha)
                .ToList();
        }

        // Guarda una nueva venta en la BD. Parámetros: venta (datos a guardar).
        public void AgregarVenta(Venta venta)
        {
            _context.Ventas.Add(venta);
            _context.SaveChanges();
        }

        // Busca una venta por su ID con todas sus relaciones. Retorna la venta o null si no existe.
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

        // Genera un número de factura único con formato FAC-YYYYMMDD-NNNNNN. Retorna el número generado.
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

        // Procesa una venta completa: valida stock, calcula totales, guarda venta y detalles, actualiza stock y cuenta corriente. Parámetros: venta (datos), detalles (lista de productos). Retorna true si se procesó correctamente, false si falló. Modifica BD con transacción.
        public bool ProcesarVenta(Venta venta, List<DetalleVenta> detalles)
        {
            // BeginTransaction: inicia una transacción para que todas las operaciones se hagan juntas (si falla una, se revierten todas).
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // Validar stock de productos
                foreach (var detalle in detalles)
                {
                    var producto = _repositorioProducto.BuscarProductoPorId(detalle.ProductoId);
                    if (producto == null || producto.Stock < detalle.Cantidad)
                    {
                        // Rollback: deshace todos los cambios de la transacción.
                        transaction.Rollback();
                        return false;
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

                // Commit: confirma todos los cambios de la transacción (todo se guarda definitivamente).
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        // Retorna ventas dentro de un rango de fechas. Parámetros: fechaInicio, fechaFin. No modifica BD.
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

        // Retorna ventas que contengan un producto específico. Parámetros: productoId. No modifica BD.
        public List<Venta> ListarVentasPorProducto(int productoId)
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor)
                .Include(v => v.Sucursal)
                .Include(v => v.DetalleVentas)
                    .ThenInclude(d => d.Producto)
                // Any: verifica si hay al menos un elemento que cumple la condición.
                .Where(v => v.DetalleVentas.Any(d => d.ProductoId == productoId))
                .AsNoTracking()
                .OrderByDescending(v => v.Fecha)
                .ToList();
        }

        // Retorna ventas de una sucursal específica. Parámetros: sucursalId. No modifica BD.
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

        // Retorna ventas realizadas por un vendedor específico. Parámetros: vendedorId. No modifica BD.
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

        // Retorna los productos más vendidos con cantidad y total vendido. Parámetros: top (cantidad de productos a retornar, default 10). No modifica BD.
        public List<dynamic> ObtenerProductosMasVendidos(int? top = 10)
        {
            return _context.DetalleVentas
                .Include(d => d.Producto)
                .AsNoTracking()
                // GroupBy: agrupa los detalles por producto.
                .GroupBy(d => new { d.ProductoId, d.Producto.Nombre })
                // Select: transforma cada grupo en un objeto anónimo con datos agregados.
                .Select(g => new
                {
                    ProductoId = g.Key.ProductoId,
                    Nombre = g.Key.Nombre,
                    // Sum: suma los valores del grupo.
                    CantidadVendida = g.Sum(d => d.Cantidad),
                    TotalVendido = g.Sum(d => d.Subtotal)
                })
                .OrderByDescending(x => x.CantidadVendida)
                // Take: limita la cantidad de resultados.
                .Take(top ?? 10)
                .ToList<dynamic>();
        }
    }
}



