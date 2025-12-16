using TechStore.Entidades;
using TechStore.Modelo;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Controladores
{
    public class CategoriaController
    {
        private readonly TechStoreDbContext _context;

        public CategoriaController(TechStoreDbContext context)
        {
            _context = context;
        }

        public List<Categoria> ObtenerTodas()
        {
            return _context.Categorias.AsNoTracking().ToList();
        }

        public Categoria? ObtenerPorId(int id)
        {
            return _context.Categorias.Find(id);
        }

        public bool Crear(Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(Categoria categoria)
        {
            try
            {
                var categoriaExistente = _context.Categorias.Find(categoria.Id);
                if (categoriaExistente == null)
                    return false;

                categoriaExistente.Nombre = categoria.Nombre;
                categoriaExistente.Descripcion = categoria.Descripcion;

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
                var categoria = _context.Categorias
                    .Include(c => c.Productos)
                    .FirstOrDefault(c => c.Id == id);

                if (categoria == null)
                    return false;

                if (categoria.Productos.Any())
                    return false; // No se puede eliminar si tiene productos

                _context.Categorias.Remove(categoria);
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

