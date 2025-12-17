using TechStore.Entidades;
using Microsoft.EntityFrameworkCore;
using System;

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
            try
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar producto: {ex.Message}", ex);
            }
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
            if (string.IsNullOrWhiteSpace(codigo))
                return null;
                
            return _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Sucursal)
                .FirstOrDefault(p => p.Codigo.Trim().ToUpper() == codigo.Trim().ToUpper());
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
            try
            {
                var productoExistente = _context.Productos.FirstOrDefault(p => p.Id == producto.Id);
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
                else
                {
                    throw new Exception($"No se encontró el producto con ID {producto.Id}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar producto: {ex.Message}", ex);
            }
        }

        public void EliminarProducto(int productoId)
        {
            try
            {
                var producto = _context.Productos.FirstOrDefault(p => p.Id == productoId);
                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception($"No se encontró el producto con ID {productoId}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar producto: {ex.Message}", ex);
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



