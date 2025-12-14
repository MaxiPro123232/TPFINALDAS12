using TechStore.Entidades;
using TechStore.Modelo;

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
            return _context.Sucursales.ToList();
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
    }
}

