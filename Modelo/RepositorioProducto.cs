using TechStore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Modelo
{
    public class RepositorioProducto
    {
        private readonly TechStoreDbContext _context;

        public RepositorioProducto()
        {
            _context = new TechStoreDbContext();
        }

        public List<Producto> ListarProductos()
        {
            return _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Sucursal)
                .AsNoTracking()
                .ToList();
        }

        public void AgregarProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
        }

        public Producto BuscarProductoPorId(int productoId)
        {
            return _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Sucursal)
                .FirstOrDefault(p => p.Id == productoId);
        }

        public Producto BuscarProductoPorCodigo(string codigo)
        {
            return _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Sucursal)
                .FirstOrDefault(p => p.Codigo == codigo);
        }

        public List<Producto> ListarProductosPorSucursal(int sucursalId)
        {
            return _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Sucursal)
                .Where(p => p.SucursalId == sucursalId)
                .ToList();
        }

        public List<Producto> ConsultarDisponibilidad(int? sucursalId, string? nombre = null)
        {
            var query = _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Sucursal)
                .Where(p => p.Stock > 0);

            if (sucursalId.HasValue && sucursalId.Value > 0)
            {
                query = query.Where(p => p.SucursalId == sucursalId.Value);
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(p => p.Nombre.Contains(nombre));
            }

            return query.AsNoTracking().ToList();
        }

        public void ActualizarProducto(Producto producto)
        {
            var productoExistente = _context.Productos.Find(producto.Id);
            if (productoExistente != null)
            {
                productoExistente.Codigo = producto.Codigo;
                productoExistente.Nombre = producto.Nombre;
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.CategoriaId = producto.CategoriaId;
                productoExistente.Precio = producto.Precio;
                productoExistente.Stock = producto.Stock;
                productoExistente.SucursalId = producto.SucursalId;
                _context.SaveChanges();
            }
        }

        public void EliminarProducto(int productoId)
        {
            var producto = _context.Productos.Find(productoId);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
        }

        public bool ActualizarStock(int productoId, int cantidad)
        {
            var producto = _context.Productos.Find(productoId);
            if (producto == null)
                return false;

            producto.Stock += cantidad;
            if (producto.Stock < 0)
                return false; // Stock insuficiente

            _context.SaveChanges();
            return true;
        }
    }
}

