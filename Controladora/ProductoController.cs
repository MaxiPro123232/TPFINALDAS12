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

        public List<Producto> ObtenerTodos()
        {
            return _repositorio.ListarProductos();
        }

        public Producto? ObtenerPorId(int id)
        {
            return _repositorio.BuscarProductoPorId(id);
        }

        public List<Producto> ObtenerPorSucursal(int sucursalId)
        {
            return _repositorio.ListarProductosPorSucursal(sucursalId);
        }

        public List<Producto> ConsultarDisponibilidad(int? sucursalId, string? nombre = null)
        {
            return _repositorio.ConsultarDisponibilidad(sucursalId, nombre);
        }

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

        public bool ActualizarStock(int productoId, int cantidad)
        {
            return _repositorio.ActualizarStock(productoId, cantidad);
        }
    }
}

