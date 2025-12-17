using TechStore.Entidades;
using TechStore.Modelo;

namespace TechStore.Controladores
{
    public class VendedorController
    {
        private readonly RepositorioVendedor _repositorio;

        public VendedorController()
        {
            _repositorio = new RepositorioVendedor();
        }

        public List<Vendedor> ObtenerTodos()
        {
            return _repositorio.ListarVendedores();
        }

        public Vendedor? ObtenerPorId(int id)
        {
            return _repositorio.BuscarVendedorPorId(id);
        }

        public List<Vendedor> ObtenerPorSucursal(int sucursalId)
        {
            return _repositorio.ListarVendedoresPorSucursal(sucursalId);
        }

        public bool Crear(Vendedor vendedor)
        {
            try
            {
                if (_repositorio.BuscarVendedorPorCodigo(vendedor.Codigo) != null)
                {
                    return false; // Código duplicado
                }

                _repositorio.AgregarVendedor(vendedor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(Vendedor vendedor)
        {
            try
            {
                var vendedorExistente = _repositorio.BuscarVendedorPorId(vendedor.Id);
                if (vendedorExistente == null)
                    return false;

                // Verificar si el código ya existe en otro vendedor
                var vendedorConMismoCodigo = _repositorio.BuscarVendedorPorCodigo(vendedor.Codigo);
                if (vendedorConMismoCodigo != null && vendedorConMismoCodigo.Id != vendedor.Id)
                {
                    return false;
                }

                vendedorExistente.Codigo = vendedor.Codigo;
                vendedorExistente.Nombre = vendedor.Nombre;
                vendedorExistente.Apellido = vendedor.Apellido;
                vendedorExistente.Telefono = vendedor.Telefono;
                vendedorExistente.SucursalId = vendedor.SucursalId;

                _repositorio.ActualizarVendedor(vendedorExistente);
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
                var vendedor = _repositorio.BuscarVendedorPorId(id);
                if (vendedor != null && vendedor.Ventas.Any())
                    return false; // No se puede eliminar si tiene ventas

                _repositorio.EliminarVendedor(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

