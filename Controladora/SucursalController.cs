using TechStore.Entidades;
using TechStore.Modelo;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Controladores
{
    public class SucursalController
    {
        private readonly TechStoreDbContext _context;

        public SucursalController(TechStoreDbContext context)
        {
            _context = context;
        }

        public List<Sucursal> ObtenerTodas()
        {
            return _context.Sucursales
                .Include(s => s.Productos)
                .Include(s => s.Ventas)
                .AsNoTracking()
                .ToList();
        }

        public Sucursal? ObtenerPorId(int id)
        {
            return _context.Sucursales.Find(id);
        }

        public bool Crear(Sucursal sucursal)
        {
            try
            {
                _context.Sucursales.Add(sucursal);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(Sucursal sucursal)
        {
            try
            {
                var sucursalExistente = _context.Sucursales.Find(sucursal.Id);
                if (sucursalExistente == null)
                    return false;

                sucursalExistente.Nombre = sucursal.Nombre;
                sucursalExistente.Direccion = sucursal.Direccion;
                sucursalExistente.Telefono = sucursal.Telefono;

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
                var sucursal = _context.Sucursales
                    .Include(s => s.Productos)
                    .Include(s => s.Ventas)
                    .FirstOrDefault(s => s.Id == id);

                if (sucursal == null)
                    return false;

                if (sucursal.Productos.Any())
                    return false; // No se puede eliminar si tiene productos

                if (sucursal.Ventas.Any())
                    return false; // No se puede eliminar si tiene ventas

                _context.Sucursales.Remove(sucursal);
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

