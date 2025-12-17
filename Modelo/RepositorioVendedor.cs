using TechStore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Modelo
{
    public class RepositorioVendedor
    {
        private readonly TechStoreDbContext _context;

        public RepositorioVendedor()
        {
            _context = new TechStoreDbContext();
        }

        // Retorna todos los vendedores con su sucursal y ventas cargadas. No modifica BD.
        public List<Vendedor> ListarVendedores()
        {
            return _context.Vendedores
                .Include(v => v.Sucursal)
                .Include(v => v.Ventas)
                .AsNoTracking()
                .ToList();
        }

        // Guarda un nuevo vendedor en la BD. Parámetros: vendedor (datos a guardar).
        public void AgregarVendedor(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
        }

        // Busca un vendedor por su ID con su sucursal cargada. Retorna el vendedor o null si no existe.
        public Vendedor BuscarVendedorPorId(int vendedorId)
        {
            return _context.Vendedores
                .Include(v => v.Sucursal)
                .FirstOrDefault(v => v.Id == vendedorId);
        }

        // Busca un vendedor por código. Retorna el vendedor o null si no existe.
        public Vendedor BuscarVendedorPorCodigo(string codigo)
        {
            return _context.Vendedores.FirstOrDefault(v => v.Codigo == codigo);
        }

        // Retorna vendedores de una sucursal específica. Parámetros: sucursalId. No modifica BD.
        public List<Vendedor> ListarVendedoresPorSucursal(int sucursalId)
        {
            return _context.Vendedores
                .Include(v => v.Sucursal)
                .Where(v => v.SucursalId == sucursalId)
                .ToList();
        }

        // Actualiza los datos de un vendedor existente. Parámetros: vendedor (con el ID y datos nuevos).
        public void ActualizarVendedor(Vendedor vendedor)
        {
            var vendedorExistente = _context.Vendedores.Find(vendedor.Id);
            if (vendedorExistente != null)
            {
                vendedorExistente.Codigo = vendedor.Codigo;
                vendedorExistente.Nombre = vendedor.Nombre;
                vendedorExistente.Apellido = vendedor.Apellido;
                vendedorExistente.Telefono = vendedor.Telefono;
                vendedorExistente.SucursalId = vendedor.SucursalId;
                _context.SaveChanges();
            }
        }

        // Elimina un vendedor de la BD. Parámetros: vendedorId.
        public void EliminarVendedor(int vendedorId)
        {
            var vendedor = _context.Vendedores
                .Include(v => v.Ventas)
                .FirstOrDefault(v => v.Id == vendedorId);

            if (vendedor != null)
            {
                _context.Vendedores.Remove(vendedor);
                _context.SaveChanges();
            }
        }
    }
}


