using TechStore.Entidades;
using TechStore.Modelo;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Controladores
{
    public class ClienteController
    {
        private readonly TechStoreDbContext _context;

        public ClienteController(TechStoreDbContext context)
        {
            _context = context;
        }

        public List<Cliente> ObtenerTodos()
        {
            return _context.Clientes.ToList();
        }

        public Cliente? ObtenerPorId(int id)
        {
            return _context.Clientes
                .Include(c => c.Ventas)
                .FirstOrDefault(c => c.Id == id);
        }

        public List<Cliente> ObtenerPorTipo(TipoCliente tipo)
        {
            return _context.Clientes
                .Where(c => c.TipoCliente == tipo)
                .ToList();
        }

        public bool Crear(Cliente cliente)
        {
            try
            {
                if (_context.Clientes.Any(c => c.Codigo == cliente.Codigo))
                {
                    return false; // Código duplicado
                }

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
                var clienteExistente = _context.Clientes.Find(cliente.Id);
                if (clienteExistente == null)
                    return false;

                // Verificar si el código ya existe en otro cliente
                if (_context.Clientes.Any(c => c.Codigo == cliente.Codigo && c.Id != cliente.Id))
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

                _context.SaveChanges();
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
                var cliente = _context.Clientes
                    .Include(c => c.Ventas)
                    .FirstOrDefault(c => c.Id == id);

                if (cliente == null)
                    return false;

                if (cliente.Ventas.Any())
                    return false; // No se puede eliminar si tiene ventas

                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
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

        public bool ActualizarSaldoCuentaCorriente(int clienteId, decimal monto)
        {
            try
            {
                var cliente = _context.Clientes.Find(clienteId);
                if (cliente == null)
                    return false;

                cliente.SaldoCuentaCorriente += monto;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

