using TechStore.Controladores;
using TechStore.Entidades;
using TechStore.Modelo;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Vistas
{
    public partial class FormGestionProductos : Form
    {
        private TechStoreDbContext _context;
        private ProductoController _controller;
        private CategoriaController _categoriaController;
        private SucursalController _sucursalController;
        private Producto? _productoSeleccionado;

        public FormGestionProductos()
        {
            InitializeComponent();
            _context = new TechStoreDbContext();
            _controller = new ProductoController(_context);
            _categoriaController = new CategoriaController(_context);
            _sucursalController = new SucursalController(_context);
            CargarDatos();
            CargarCombos();
        }

        private void CargarCombos()
        {
            cmbCategoria.DataSource = null;
            cmbCategoria.DataSource = _categoriaController.ObtenerTodas();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";

            cmbSucursal.DataSource = null;
            cmbSucursal.DataSource = _sucursalController.ObtenerTodas();
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "Id";

            cmbSucursalConsulta.DataSource = null;
            cmbSucursalConsulta.DataSource = _sucursalController.ObtenerTodas();
            cmbSucursalConsulta.DisplayMember = "Nombre";
            cmbSucursalConsulta.ValueMember = "Id";
        }

        private void CargarDatos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = _controller.ObtenerTodos();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _productoSeleccionado = null;
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cmbCategoria.SelectedIndex = -1;
            cmbSucursal.SelectedIndex = -1;
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
            if (!ValidarDatos())
                return;

            var producto = new Producto
            {
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                CategoriaId = (int)cmbCategoria.SelectedValue,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                SucursalId = (int)cmbSucursal.SelectedValue
            };

            if (_productoSeleccionado == null)
            {
                if (_controller.Crear(producto))
                {
                    MessageBox.Show("Producto creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al crear el producto. Verifique que el código no esté duplicado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                producto.Id = _productoSeleccionado.Id;
                if (_controller.Actualizar(producto))
                {
                    MessageBox.Show("Producto actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionado == null)
                return;

            txtCodigo.Text = _productoSeleccionado.Codigo;
            txtNombre.Text = _productoSeleccionado.Nombre;
            txtDescripcion.Text = _productoSeleccionado.Descripcion ?? "";
            txtPrecio.Text = _productoSeleccionado.Precio.ToString();
            txtStock.Text = _productoSeleccionado.Stock.ToString();
            cmbCategoria.SelectedValue = _productoSeleccionado.CategoriaId;
            cmbSucursal.SelectedValue = _productoSeleccionado.SucursalId;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionado == null)
                return;

            if (MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_controller.Eliminar(_productoSeleccionado.Id))
                {
                    MessageBox.Show("Producto eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                var producto = (Producto)dgvProductos.SelectedRows[0].DataBoundItem;
                _productoSeleccionado = _controller.ObtenerPorId(producto.Id);
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                btnNuevo.Enabled = true;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cmbSucursalConsulta.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una sucursal.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sucursalId = (int)cmbSucursalConsulta.SelectedValue;
            string? nombre = string.IsNullOrWhiteSpace(txtNombreConsulta.Text) ? null : txtNombreConsulta.Text.Trim();

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = _controller.ConsultarDisponibilidad(sucursalId, nombre);
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El código es requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("El stock debe ser un número mayor o igual a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbSucursal.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una sucursal.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}

