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

        // Retorna todas las sucursales con sus productos y ventas cargados. No modifica BD.
        public List<Sucursal> ListarSucursales()
        {
            return _context.Sucursales
                .Include(s => s.Productos)
                .Include(s => s.Ventas)
                .AsNoTracking()
                .ToList();
        }

        // Guarda una nueva sucursal en la BD. Parámetros: sucursal (datos a guardar).
        public void AgregarSucursal(Sucursal sucursal)
        {
            _context.Sucursales.Add(sucursal);
            _context.SaveChanges();
        }

        // Busca una sucursal por su ID. Retorna la sucursal o null si no existe.
        public Sucursal BuscarSucursalPorId(int sucursalId)
        {
            return _context.Sucursales.Find(sucursalId);
        }

        // Actualiza los datos de una sucursal existente. Parámetros: sucursal (con el ID y datos nuevos).
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

        // Elimina una sucursal de la BD. Parámetros: sucursalId.
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



