using TechStore.Controladores;
using TechStore.Entidades;
using TechStore.Modelo;

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
            _controller = new CategoriaController(_context);
            CargarDatos();
        }

        private void CargarDatos()
        {
            dgvCategorias.DataSource = _controller.ObtenerTodas();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _categoriaSeleccionada = null;
            txtNombre.Clear();
            txtDescripcion.Clear();
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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

            if (_categoriaSeleccionada == null)
            {
                if (_controller.Crear(categoria))
                {
                    MessageBox.Show("Categoría creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al crear la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                categoria.Id = _categoriaSeleccionada.Id;
                if (_controller.Actualizar(categoria))
                {
                    MessageBox.Show("Categoría actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_categoriaSeleccionada == null)
                return;

            txtNombre.Text = _categoriaSeleccionada.Nombre;
            txtDescripcion.Text = _categoriaSeleccionada.Descripcion ?? "";
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = true;
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
                _categoriaSeleccionada = (Categoria)dgvCategorias.SelectedRows[0].DataBoundItem;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                btnNuevo.Enabled = true;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}

