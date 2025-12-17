using TechStore.Entidades;
using TechStore.Modelo;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Controladores
{
    public class VendedorController
    {
        private readonly TechStoreDbContext _context;

        public VendedorController(TechStoreDbContext context)
        {
            _context = context;
        }

        public List<Vendedor> ObtenerTodos()
        {
            return _context.Vendedores
                .Include(v => v.Sucursal)
                .Include(v => v.Ventas)
                .AsNoTracking()
                .ToList();
        }

        public Vendedor? ObtenerPorId(int id)
        {
            return _context.Vendedores
                .Include(v => v.Sucursal)
                .FirstOrDefault(v => v.Id == id);
        }

        public List<Vendedor> ObtenerPorSucursal(int sucursalId)
        {
            return _context.Vendedores
                .Include(v => v.Sucursal)
                .Where(v => v.SucursalId == sucursalId)
                .ToList();
        }

        public bool Crear(Vendedor vendedor)
        {
            try
            {
                if (_context.Vendedores.Any(v => v.Codigo == vendedor.Codigo))
                {
                    return false; // Código duplicado
                }

                _context.Vendedores.Add(vendedor);
                _context.SaveChanges();
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
                var vendedorExistente = _context.Vendedores.Find(vendedor.Id);
                if (vendedorExistente == null)
                    return false;

                // Verificar si el código ya existe en otro vendedor
                if (_context.Vendedores.Any(v => v.Codigo == vendedor.Codigo && v.Id != vendedor.Id))
                {
                    return false;
                }

                vendedorExistente.Codigo = vendedor.Codigo;
                vendedorExistente.Nombre = vendedor.Nombre;
                vendedorExistente.Apellido = vendedor.Apellido;
                vendedorExistente.Telefono = vendedor.Telefono;
                vendedorExistente.SucursalId = vendedor.SucursalId;

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
                var vendedor = _context.Vendedores
                    .Include(v => v.Ventas)
                    .FirstOrDefault(v => v.Id == id);

                if (vendedor == null)
                    return false;

                if (vendedor.Ventas.Any())
                    return false; // No se puede eliminar si tiene ventas

                _context.Vendedores.Remove(vendedor);
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

