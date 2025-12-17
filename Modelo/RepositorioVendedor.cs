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

        public List<Vendedor> ListarVendedores()
        {
            return _context.Vendedores
                .Include(v => v.Sucursal)
                .Include(v => v.Ventas)
                .AsNoTracking()
                .ToList();
        }

        public void AgregarVendedor(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
        }

        public Vendedor BuscarVendedorPorId(int vendedorId)
        {
            return _context.Vendedores
                .Include(v => v.Sucursal)
                .FirstOrDefault(v => v.Id == vendedorId);
        }

        public Vendedor BuscarVendedorPorCodigo(string codigo)
        {
            return _context.Vendedores.FirstOrDefault(v => v.Codigo == codigo);
        }

        public List<Vendedor> ListarVendedoresPorSucursal(int sucursalId)
        {
            return _context.Vendedores
                .Include(v => v.Sucursal)
                .Where(v => v.SucursalId == sucursalId)
                .ToList();
        }

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


