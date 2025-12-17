using TechStore.Entidades;
using TechStore.Modelo;

namespace TechStore.Controladores
{
    public class ClienteController
    {
        private readonly RepositorioCliente _repositorio;

        public ClienteController()
        {
            _repositorio = new RepositorioCliente();
        }

        public List<Cliente> ObtenerTodos()
        {
            return _repositorio.ListarClientes();
        }

        public Cliente? ObtenerPorId(int id)
        {
            return _repositorio.BuscarClientePorId(id);
        }

        public List<Cliente> ObtenerPorTipo(TipoCliente tipo)
        {
            return _repositorio.ListarClientesPorTipo(tipo);
        }

        public bool Crear(Cliente cliente)
        {
            try
            {
                if (_repositorio.BuscarClientePorCodigo(cliente.Codigo) != null)
                {
                    return false; // Código duplicado
                }

                _repositorio.AgregarCliente(cliente);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(Cliente cliente)
        {
            try
            {
                var clienteExistente = _repositorio.BuscarClientePorId(cliente.Id);
                if (clienteExistente == null)
                    return false;

                // Verificar si el código ya existe en otro cliente
                var clienteConMismoCodigo = _repositorio.BuscarClientePorCodigo(cliente.Codigo);
                if (clienteConMismoCodigo != null && clienteConMismoCodigo.Id != cliente.Id)
                {
                    return false;
                }

                clienteExistente.Codigo = cliente.Codigo;
                clienteExistente.Nombre = cliente.Nombre;
                clienteExistente.Apellido = cliente.Apellido;
                clienteExistente.Direccion = cliente.Direccion;
                clienteExistente.Telefono = cliente.Telefono;
                clienteExistente.Email = cliente.Email;
                clienteExistente.TipoCliente = cliente.TipoCliente;
                clienteExistente.Descuento = cliente.Descuento;

                _repositorio.ActualizarCliente(clienteExistente);
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
                var cliente = _repositorio.BuscarClientePorId(id);
                if (cliente == null)
                    return false;

                if (cliente.Ventas.Any())
                    return false; // No se puede eliminar si tiene ventas

                _repositorio.EliminarCliente(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Venta> ObtenerHistorialCompras(int clienteId)
        {
            return _repositorio.ObtenerHistorialCompras(clienteId);
        }

        public decimal ObtenerSaldoCuentaCorriente(int clienteId)
        {
            return _repositorio.ObtenerSaldoCuentaCorriente(clienteId);
        }

        public bool ActualizarSaldoCuentaCorriente(int clienteId, decimal monto)
        {
            try
            {
                _repositorio.ActualizarSaldoCuentaCorriente(clienteId, monto);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

