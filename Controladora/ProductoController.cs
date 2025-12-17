using TechStore.Entidades;
using TechStore.Modelo;
using System;

namespace TechStore.Controladores
{
    public class ProductoController
    {
        private readonly RepositorioProducto _repositorio;

        public ProductoController()
        {
            _repositorio = new RepositorioProducto();
        }

        // Retorna todos los productos. No modifica BD.
        public List<Producto> ObtenerTodos()
        {
            return _repositorio.ListarProductos();
        }

        // Busca un producto por ID. Parámetros: id. Retorna el producto o null.
        public Producto? ObtenerPorId(int id)
        {
            return _repositorio.BuscarProductoPorId(id);
        }

        // Retorna productos de una sucursal específica. Parámetros: sucursalId. No modifica BD.
        public List<Producto> ObtenerPorSucursal(int sucursalId)
        {
            return _repositorio.ListarProductosPorSucursal(sucursalId);
        }

        // Busca productos disponibles filtrados por sucursal y/o nombre. Parámetros: sucursalId (opcional), nombre (opcional). No modifica BD.
        public List<Producto> ConsultarDisponibilidad(int? sucursalId, string? nombre = null)
        {
            return _repositorio.ConsultarDisponibilidad(sucursalId, nombre);
        }

        // Crea un nuevo producto. Valida duplicados por código. Parámetros: producto. Retorna true si se creó, false si falló o código duplicado.
        public bool Crear(Producto producto)
        {
            try
            {
                if (_repositorio.BuscarProductoPorCodigo(producto.Codigo) != null)
                {
                    return false; // Código duplicado
                }

                _repositorio.AgregarProducto(producto);
                return true;
            }
            catch (Exception ex)
            {
                // Log del error para debugging
                System.Diagnostics.Debug.WriteLine($"Error al crear producto: {ex.Message}");
                return false;
            }
        }

        // Actualiza un producto existente. Valida duplicados por código. Parámetros: producto (con ID y datos nuevos). Retorna true si se actualizó, false si falló.
        public bool Actualizar(Producto producto)
        {
            try
            {
                var productoExistente = _repositorio.BuscarProductoPorId(producto.Id);
                if (productoExistente == null)
                    return false;

                // Verificar si el código ya existe en otro producto
                var productoConMismoCodigo = _repositorio.BuscarProductoPorCodigo(producto.Codigo);
                if (productoConMismoCodigo != null && productoConMismoCodigo.Id != producto.Id)
                {
                    return false;
                }

                _repositorio.ActualizarProducto(producto);
                return true;
            }
            catch (Exception ex)
            {
                // Log del error para debugging
                System.Diagnostics.Debug.WriteLine($"Error al actualizar producto: {ex.Message}");
                return false;
            }
        }

        // Elimina un producto. Parámetros: id. Retorna true si se eliminó, false si falló.
        public bool Eliminar(int id)
        {
            try
            {
                _repositorio.EliminarProducto(id);
                return true;
            }
            catch (Exception ex)
            {
                // Log del error para debugging
                System.Diagnostics.Debug.WriteLine($"Error al eliminar producto: {ex.Message}");
                return false;
            }
        }

        // Actualiza el stock de un producto. Parámetros: productoId, cantidad (puede ser negativa). Retorna true si se actualizó, false si falló. Modifica BD.
        public bool ActualizarStock(int productoId, int cantidad)
        {
            return _repositorio.ActualizarStock(productoId, cantidad);
        }
    }
}

