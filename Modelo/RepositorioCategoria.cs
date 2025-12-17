using TechStore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Modelo
{
    public class RepositorioCategoria
    {
        private readonly TechStoreDbContext _context;

        public RepositorioCategoria()
        {
            _context = new TechStoreDbContext();
        }

        public List<Categoria> ListarCategorias()
        {
            return _context.Categorias
                .Include(c => c.Productos)
                .AsNoTracking()
                .ToList();
        }

        public void AgregarCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public Categoria BuscarCategoriaPorId(int categoriaId)
        {
            return _context.Categorias
                .Include(c => c.Productos)
                .FirstOrDefault(c => c.Id == categoriaId);
        }

        public bool TieneProductos(int categoriaId)
        {
            return _context.Categorias
                .Include(c => c.Productos)
                .Where(c => c.Id == categoriaId)
                .SelectMany(c => c.Productos)
                .Any();
        }

        public void ActualizarCategoria(Categoria categoria)
        {
            var categoriaExistente = _context.Categorias.Find(categoria.Id);
            if (categoriaExistente != null)
            {
                categoriaExistente.Nombre = categoria.Nombre;
                categoriaExistente.Descripcion = categoria.Descripcion;
                _context.SaveChanges();
            }
        }

        public void EliminarCategoria(int categoriaId)
        {
            var categoria = _context.Categorias.Find(categoriaId);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
            }
        }
    }
}

