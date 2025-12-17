using TechStore.Entidades;
using TechStore.Modelo;

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
            catch
            {
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

                productoExistente.Codigo = producto.Codigo;
                productoExistente.Nombre = producto.Nombre;
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.CategoriaId = producto.CategoriaId;
                productoExistente.Precio = producto.Precio;
                productoExistente.Stock = producto.Stock;
                productoExistente.SucursalId = producto.SucursalId;

                _repositorio.ActualizarProducto(productoExistente);
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
                _repositorio.EliminarProducto(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ActualizarStock(int productoId, int cantidad)
        {
            return _repositorio.ActualizarStock(productoId, cantidad);
        }
    }
}

