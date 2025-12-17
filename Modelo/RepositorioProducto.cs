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

        // Retorna todos los productos con sus relaciones cargadas. No modifica BD.
        public List<Producto> ListarProductos()
        {
            // Include: trae también la entidad relacionada (evita hacer otra consulta para Categoria y Sucursal).
            return _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Sucursal)
                // AsNoTracking: no guarda cambios de estas entidades (mejora rendimiento en solo lectura).
                .AsNoTracking()
                // ToList: ejecuta la consulta y convierte el resultado en una lista.
                .ToList();
        }

        // Guarda un nuevo producto en la BD. Parámetros: producto (datos a guardar).
        public void AgregarProducto(Producto producto)
        {
            try
            {
                _context.Productos.Add(producto);
                // SaveChanges: persiste los cambios en la base de datos.
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar producto: {ex.Message}", ex);
            }
        }

        // Busca un producto por su ID. Retorna el producto con relaciones cargadas, o null si no existe.
        public Producto BuscarProductoPorId(int productoId)
        {
            return _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Sucursal)
                // FirstOrDefault: retorna el primer elemento que cumple la condición, o null si no hay ninguno.
                .FirstOrDefault(p => p.Id == productoId);
        }

        // Busca un producto por código (sin distinguir mayúsculas/minúsculas). Retorna el producto o null.
        public Producto BuscarProductoPorCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return null;
                
            return _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Sucursal)
                .FirstOrDefault(p => p.Codigo.Trim().ToUpper() == codigo.Trim().ToUpper());
        }

        // Retorna productos de una sucursal específica. Parámetros: sucursalId. No modifica BD.
        public List<Producto> ListarProductosPorSucursal(int sucursalId)
        {
            return _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Sucursal)
                // Where: filtra los resultados según la condición.
                .Where(p => p.SucursalId == sucursalId)
                .ToList();
        }

        // Busca productos con stock disponible, opcionalmente filtrados por sucursal y/o nombre. Parámetros: sucursalId (opcional), nombre (opcional). Retorna lista de productos disponibles.
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

        // Actualiza los datos de un producto existente en la BD. Parámetros: producto (con el ID y datos nuevos).
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

        // Elimina un producto de la BD. Parámetros: productoId.
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

        // Incrementa o decrementa el stock de un producto. Parámetros: productoId, cantidad (puede ser negativa). Retorna true si se actualizó, false si no existe o stock insuficiente. Modifica BD.
        public bool ActualizarStock(int productoId, int cantidad)
        {
            // Find: busca por clave primaria (más rápido que FirstOrDefault cuando buscas por ID).
            var producto = _context.Productos.Find(productoId);
            if (producto == null)
                return false;

            producto.Stock += cantidad;
            if (producto.Stock < 0)
                return false;

            _context.SaveChanges();
            return true;
        }
    }
}



