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

        public List<Categoria> ObtenerTodas()
        {
            return _repositorio.ListarCategorias();
        }

        public Categoria? ObtenerPorId(int id)
        {
            return _repositorio.BuscarCategoriaPorId(id);
        }

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

