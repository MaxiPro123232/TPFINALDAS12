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

        // Retorna todos los vendedores. No modifica BD.
        public List<Vendedor> ObtenerTodos()
        {
            return _repositorio.ListarVendedores();
        }

        // Busca un vendedor por ID. Parámetros: id. Retorna el vendedor o null.
        public Vendedor? ObtenerPorId(int id)
        {
            return _repositorio.BuscarVendedorPorId(id);
        }

        // Retorna vendedores de una sucursal específica. Parámetros: sucursalId. No modifica BD.
        public List<Vendedor> ObtenerPorSucursal(int sucursalId)
        {
            return _repositorio.ListarVendedoresPorSucursal(sucursalId);
        }

        // Crea un nuevo vendedor. Valida duplicados por código. Parámetros: vendedor. Retorna true si se creó, false si falló o código duplicado.
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

        // Actualiza un vendedor existente. Valida duplicados por código. Parámetros: vendedor (con ID y datos nuevos). Retorna true si se actualizó, false si falló.
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

        // Elimina un vendedor si no tiene ventas asociadas. Parámetros: id. Retorna true si se eliminó, false si falló o tiene ventas.
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

