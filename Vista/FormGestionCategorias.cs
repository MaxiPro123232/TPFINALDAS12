using TechStore.Controladores;
using TechStore.Entidades;
using TechStore.Modelo;
using System.Linq;
using System.Reflection;

namespace TechStore.Vistas
{
    public partial class FormGestionCategorias : Form
    {
        private TechStoreDbContext _context;
        private CategoriaController _controller;
        private Categoria? _categoriaSeleccionada;

        public FormGestionCategorias()
        {
            InitializeComponent();
            _context = new TechStoreDbContext();
            _controller = new CategoriaController();
            CargarDatos();
        }

        private void CargarDatos()
        {
            dgvCategorias.DataSource = null;
            var categorias = _controller.ObtenerTodas();
            dgvCategorias.DataSource = categorias.Select(c => new
            {
                c.Id,
                c.Nombre,
                c.Descripcion,
                Productos = c.Productos != null && c.Productos.Any() 
                    ? string.Join(" - ", c.Productos.Select(p => p.Nombre))
                    : ""
            }).ToList();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _categoriaSeleccionada = null;
            txtNombre.Clear();
            txtDescripcion.Clear();
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnLimpiar.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var categoria = new Categoria
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim()
            };

            // Guardar siempre crea nuevo, ignorando cualquier selección
            if (_controller.Crear(categoria))
            {
                MessageBox.Show("Categoría creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al crear la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_categoriaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una categoría para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var categoria = new Categoria
            {
                Id = _categoriaSeleccionada.Id,
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim()
            };

            if (_controller.Actualizar(categoria))
            {
                MessageBox.Show("Categoría actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al actualizar la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_categoriaSeleccionada == null)
                return;

            if (MessageBox.Show("¿Está seguro de eliminar esta categoría?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_controller.Eliminar(_categoriaSeleccionada.Id))
                {
                    MessageBox.Show("Categoría eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la categoría. Verifique que no tenga productos asociados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                // Obtener el ID del objeto anónimo
                var selectedRow = dgvCategorias.SelectedRows[0].DataBoundItem;
                var idProperty = selectedRow.GetType().GetProperty("Id");
                if (idProperty != null)
                {
                    int categoriaId = (int)idProperty.GetValue(selectedRow)!;
                    _categoriaSeleccionada = _controller.ObtenerPorId(categoriaId);
                    if (_categoriaSeleccionada != null)
                    {
                        txtNombre.Text = _categoriaSeleccionada.Nombre;
                        txtDescripcion.Text = _categoriaSeleccionada.Descripcion ?? "";
                    }
                    btnActualizar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnLimpiar.Enabled = true;
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}

