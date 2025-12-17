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

        public List<Cliente> ListarClientes()
        {
            return _context.Clientes
                .AsNoTracking()
                .ToList();
        }

        public void AgregarCliente(Cliente cliente)
        {
            // Aplicar descuento según tipo de cliente
            if (cliente.TipoCliente == TipoCliente.Mayorista && cliente.Descuento == 0)
            {
                cliente.Descuento = 15; // Descuento por defecto para mayoristas
            }
            else if (cliente.TipoCliente == TipoCliente.Minorista)
            {
                cliente.Descuento = 0; // Sin descuento para minoristas por defecto
            }

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public Cliente BuscarClientePorId(int clienteId)
        {
            return _context.Clientes
                .Include(c => c.Ventas)
                .FirstOrDefault(c => c.Id == clienteId);
        }

        public Cliente BuscarClientePorCodigo(string codigo)
        {
            return _context.Clientes.FirstOrDefault(c => c.Codigo == codigo);
        }

        public List<Cliente> ListarClientesPorTipo(TipoCliente tipo)
        {
            return _context.Clientes
                .Where(c => c.TipoCliente == tipo)
                .ToList();
        }

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

        public decimal ObtenerSaldoCuentaCorriente(int clienteId)
        {
            var cliente = _context.Clientes.Find(clienteId);
            return cliente?.SaldoCuentaCorriente ?? 0;
        }

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

