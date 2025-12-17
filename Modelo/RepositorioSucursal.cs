using TechStore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Modelo
{
    public class RepositorioSucursal
    {
        private readonly TechStoreDbContext _context;

        public RepositorioSucursal()
        {
            _context = new TechStoreDbContext();
        }

        public List<Sucursal> ListarSucursales()
        {
            return _context.Sucursales
                .Include(s => s.Productos)
                .Include(s => s.Ventas)
                .AsNoTracking()
                .ToList();
        }

        public void AgregarSucursal(Sucursal sucursal)
        {
            _context.Sucursales.Add(sucursal);
            _context.SaveChanges();
        }

        public Sucursal BuscarSucursalPorId(int sucursalId)
        {
            return _context.Sucursales.Find(sucursalId);
        }

        public void ActualizarSucursal(Sucursal sucursal)
        {
            var sucursalExistente = _context.Sucursales.Find(sucursal.Id);
            if (sucursalExistente != null)
            {
                sucursalExistente.Nombre = sucursal.Nombre;
                sucursalExistente.Direccion = sucursal.Direccion;
                sucursalExistente.Telefono = sucursal.Telefono;
                _context.SaveChanges();
            }
        }

        public void EliminarSucursal(int sucursalId)
        {
            var sucursal = _context.Sucursales
                .Include(s => s.Productos)
                .Include(s => s.Ventas)
                .FirstOrDefault(s => s.Id == sucursalId);

            if (sucursal != null)
            {
                _context.Sucursales.Remove(sucursal);
                _context.SaveChanges();
            }
        }
    }
}



