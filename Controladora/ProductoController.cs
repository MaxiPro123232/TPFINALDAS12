using TechStore.Entidades;
using TechStore.Modelo;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Controladores
{
    public class ProductoController
    {
        private readonly TechStoreDbContext _context;

        public ProductoController(TechStoreDbContext context)
        {
            _context = context;
        }

        public List<Producto> ObtenerTodos()
        {
            return _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Sucursal)
                .ToList();
        }

        public Producto? ObtenerPorId(int id)
        {
            return _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Sucursal)
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Producto> ObtenerPorSucursal(int sucursalId)
        {
            return _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Sucursal)
                .Where(p => p.SucursalId == sucursalId)
                .ToList();
        }

        public List<Producto> ConsultarDisponibilidad(int sucursalId, string? nombre = null)
        {
            var query = _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Sucursal)
                .Where(p => p.SucursalId == sucursalId && p.Stock > 0);

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(p => p.Nombre.Contains(nombre));
            }

            return query.ToList();
        }

        public bool Crear(Producto producto)
        {
            try
            {
                if (_context.Productos.Any(p => p.Codigo == producto.Codigo))
                {
                    return false; // Código duplicado
                }

                _context.Productos.Add(producto);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(Producto producto)
        {
            try
            {
                var productoExistente = _context.Productos.Find(producto.Id);
                if (productoExistente == null)
                    return false;

                // Verificar si el código ya existe en otro producto
                if (_context.Productos.Any(p => p.Codigo == producto.Codigo && p.Id != producto.Id))
                {
                    return false;
                }

                productoExistente.Codigo = producto.Codigo;
                productoExistente.Nombre = producto.Nombre;
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.CategoriaId = producto.CategoriaId;
                productoExistente.Precio = producto.Precio;
                productoExistente.Stock = producto.Stock;
                productoExistente.SucursalId = producto.SucursalId;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                var producto = _context.Productos.Find(id);
                if (producto == null)
                    return false;

                _context.Productos.Remove(producto);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ActualizarStock(int productoId, int cantidad)
        {
            try
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
            catch
            {
                return false;
            }
        }
    }
}

