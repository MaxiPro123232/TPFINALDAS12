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

        // Retorna todos los clientes. No modifica BD.
        public List<Cliente> ObtenerTodos()
        {
            return _repositorio.ListarClientes();
        }

        // Busca un cliente por ID. Parámetros: id. Retorna el cliente o null.
        public Cliente? ObtenerPorId(int id)
        {
            return _repositorio.BuscarClientePorId(id);
        }

        // Retorna clientes filtrados por tipo. Parámetros: tipo. No modifica BD.
        public List<Cliente> ObtenerPorTipo(TipoCliente tipo)
        {
            return _repositorio.ListarClientesPorTipo(tipo);
        }

        // Crea un nuevo cliente. Valida duplicados por código. Parámetros: cliente. Retorna true si se creó, false si falló o código duplicado.
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

        // Actualiza un cliente existente. Valida duplicados por código. Parámetros: cliente (con ID y datos nuevos). Retorna true si se actualizó, false si falló.
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

        // Elimina un cliente si no tiene ventas asociadas. Parámetros: id. Retorna true si se eliminó, false si falló o tiene ventas.
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

        // Retorna el historial de compras de un cliente. Parámetros: clienteId. No modifica BD.
        public List<Venta> ObtenerHistorialCompras(int clienteId)
        {
            return _repositorio.ObtenerHistorialCompras(clienteId);
        }

        // Obtiene el saldo de cuenta corriente de un cliente. Parámetros: clienteId. Retorna el saldo o 0. No modifica BD.
        public decimal ObtenerSaldoCuentaCorriente(int clienteId)
        {
            return _repositorio.ObtenerSaldoCuentaCorriente(clienteId);
        }

        // Actualiza el saldo de cuenta corriente de un cliente. Parámetros: clienteId, monto (puede ser negativo). Retorna true si se actualizó, false si falló. Modifica BD.
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

