using TechStore.Entidades;
using TechStore.Modelo;

namespace TechStore.Controladores
{
    public class CategoriaController
    {
        private readonly RepositorioCategoria _repositorio;

        public CategoriaController()
        {
            _repositorio = new RepositorioCategoria();
        }

        // Retorna todas las categorías. No modifica BD.
        public List<Categoria> ObtenerTodas()
        {
            return _repositorio.ListarCategorias();
        }

        // Busca una categoría por ID. Parámetros: id. Retorna la categoría o null.
        public Categoria? ObtenerPorId(int id)
        {
            return _repositorio.BuscarCategoriaPorId(id);
        }

        // Crea una nueva categoría. Parámetros: categoria. Retorna true si se creó, false si falló.
        public bool Crear(Categoria categoria)
        {
            try
            {
                _repositorio.AgregarCategoria(categoria);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Actualiza una categoría existente. Parámetros: categoria (con ID y datos nuevos). Retorna true si se actualizó, false si falló.
        public bool Actualizar(Categoria categoria)
        {
            try
            {
                var categoriaExistente = _repositorio.BuscarCategoriaPorId(categoria.Id);
                if (categoriaExistente == null)
                    return false;

                categoriaExistente.Nombre = categoria.Nombre;
                categoriaExistente.Descripcion = categoria.Descripcion;

                _repositorio.ActualizarCategoria(categoriaExistente);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Elimina una categoría si no tiene productos asociados. Parámetros: id. Retorna true si se eliminó, false si falló o tiene productos.
        public bool Eliminar(int id)
        {
            try
            {
                if (_repositorio.TieneProductos(id))
                    return false; // No se puede eliminar si tiene productos

                _repositorio.EliminarCategoria(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

