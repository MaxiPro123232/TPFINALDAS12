using TechStore.Entidades;
using TechStore.Modelo;

namespace TechStore.Controladores
{
    public class SucursalController
    {
        private readonly RepositorioSucursal _repositorio;

        public SucursalController()
        {
            _repositorio = new RepositorioSucursal();
        }

        public List<Sucursal> ObtenerTodas()
        {
            return _repositorio.ListarSucursales();
        }

        public Sucursal? ObtenerPorId(int id)
        {
            return _repositorio.BuscarSucursalPorId(id);
        }

        public bool Crear(Sucursal sucursal)
        {
            try
            {
                _repositorio.AgregarSucursal(sucursal);
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
                var sucursalExistente = _repositorio.BuscarSucursalPorId(sucursal.Id);
                if (sucursalExistente == null)
                    return false;

                sucursalExistente.Nombre = sucursal.Nombre;
                sucursalExistente.Direccion = sucursal.Direccion;
                sucursalExistente.Telefono = sucursal.Telefono;

                _repositorio.ActualizarSucursal(sucursalExistente);
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
                var sucursal = _repositorio.ListarSucursales().FirstOrDefault(s => s.Id == id);
                if (sucursal == null)
                    return false;

                if (sucursal.Productos.Any() || sucursal.Ventas.Any())
                    return false; // No se puede eliminar si tiene productos o ventas

                _repositorio.EliminarSucursal(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

