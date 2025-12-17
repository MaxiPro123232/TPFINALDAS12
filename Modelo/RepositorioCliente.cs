using TechStore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Modelo
{
    public class RepositorioCliente
    {
        private readonly TechStoreDbContext _context;

        public RepositorioCliente()
        {
            _context = new TechStoreDbContext();
        }

        // Retorna todos los clientes con sus ventas cargadas. No modifica BD.
        public List<Cliente> ListarClientes()
        {
            return _context.Clientes
                .Include(c => c.Ventas)
                .AsNoTracking()
                .ToList();
        }

        // Guarda un nuevo cliente en la BD, aplicando descuento por defecto según tipo (15% mayoristas, 0% minoristas). Parámetros: cliente (datos a guardar).
        public void AgregarCliente(Cliente cliente)
        {
            if (cliente.TipoCliente == TipoCliente.Mayorista && cliente.Descuento == 0)
            {
                cliente.Descuento = 15;
            }
            else if (cliente.TipoCliente == TipoCliente.Minorista)
            {
                cliente.Descuento = 0;
            }

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        // Busca un cliente por su ID con sus ventas cargadas. Retorna el cliente o null si no existe.
        public Cliente BuscarClientePorId(int clienteId)
        {
            return _context.Clientes
                .Include(c => c.Ventas)
                .FirstOrDefault(c => c.Id == clienteId);
        }

        // Busca un cliente por código. Retorna el cliente o null si no existe.
        public Cliente BuscarClientePorCodigo(string codigo)
        {
            return _context.Clientes.FirstOrDefault(c => c.Codigo == codigo);
        }

        // Retorna clientes filtrados por tipo. Parámetros: tipo. No modifica BD.
        public List<Cliente> ListarClientesPorTipo(TipoCliente tipo)
        {
            return _context.Clientes
                .Where(c => c.TipoCliente == tipo)
                .ToList();
        }

        // Actualiza los datos de un cliente existente. Parámetros: cliente (con el ID y datos nuevos).
        public void ActualizarCliente(Cliente cliente)
        {
            var clienteExistente = _context.Clientes.Find(cliente.Id);
            if (clienteExistente != null)
            {
                clienteExistente.Codigo = cliente.Codigo;
                clienteExistente.Nombre = cliente.Nombre;
                clienteExistente.Apellido = cliente.Apellido;
                clienteExistente.Direccion = cliente.Direccion;
                clienteExistente.Telefono = cliente.Telefono;
                clienteExistente.Email = cliente.Email;
                clienteExistente.TipoCliente = cliente.TipoCliente;
                clienteExistente.Descuento = cliente.Descuento;
                _context.SaveChanges();
            }
        }

        // Elimina un cliente de la BD. Parámetros: clienteId.
        public void EliminarCliente(int clienteId)
        {
            var cliente = _context.Clientes
                .Include(c => c.Ventas)
                .FirstOrDefault(c => c.Id == clienteId);

            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }

        // Retorna el historial de compras de un cliente con todas las relaciones. Parámetros: clienteId. No modifica BD.
        public List<Venta> ObtenerHistorialCompras(int clienteId)
        {
            return _context.Ventas
                .Include(v => v.Vendedor)
                .Include(v => v.Sucursal)
                .Include(v => v.DetalleVentas)
                    .ThenInclude(d => d.Producto)
                .Where(v => v.ClienteId == clienteId)
                .OrderByDescending(v => v.Fecha)
                .ToList();
        }

        // Obtiene el saldo de cuenta corriente de un cliente. Parámetros: clienteId. Retorna el saldo o 0 si no existe. No modifica BD.
        public decimal ObtenerSaldoCuentaCorriente(int clienteId)
        {
            var cliente = _context.Clientes.Find(clienteId);
            return cliente?.SaldoCuentaCorriente ?? 0;
        }

        // Incrementa o decrementa el saldo de cuenta corriente de un cliente. Parámetros: clienteId, monto (puede ser negativo). Modifica BD.
        public void ActualizarSaldoCuentaCorriente(int clienteId, decimal monto)
        {
            var cliente = _context.Clientes.Find(clienteId);
            if (cliente != null)
            {
                cliente.SaldoCuentaCorriente += monto;
                _context.SaveChanges();
            }
        }
    }
}


