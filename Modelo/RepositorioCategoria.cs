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

        // Retorna todas las categorías con sus productos cargados. No modifica BD.
        public List<Categoria> ListarCategorias()
        {
            return _context.Categorias
                .Include(c => c.Productos)
                .AsNoTracking()
                .ToList();
        }

        // Guarda una nueva categoría en la BD. Parámetros: categoria (datos a guardar).
        public void AgregarCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        // Busca una categoría por su ID con sus productos cargados. Retorna la categoría o null si no existe.
        public Categoria BuscarCategoriaPorId(int categoriaId)
        {
            return _context.Categorias
                .Include(c => c.Productos)
                .FirstOrDefault(c => c.Id == categoriaId);
        }

        // Verifica si una categoría tiene productos asociados. Parámetros: categoriaId. Retorna true si tiene productos, false si no. No modifica BD.
        public bool TieneProductos(int categoriaId)
        {
            return _context.Categorias
                .Include(c => c.Productos)
                .Where(c => c.Id == categoriaId)
                // SelectMany: aplanar colecciones anidadas (transforma cada categoría en sus productos).
                .SelectMany(c => c.Productos)
                .Any();
        }

        // Actualiza los datos de una categoría existente. Parámetros: categoria (con el ID y datos nuevos).
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

        // Elimina una categoría de la BD. Parámetros: categoriaId.
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



