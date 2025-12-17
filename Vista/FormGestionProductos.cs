using TechStore.Controladores;
using TechStore.Entidades;
using TechStore.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

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

            // Cargar sucursales para consulta con opción "Todas"
            cmbSucursalConsulta.DataSource = null;
            var sucursales = _sucursalController.ObtenerTodas();
            var sucursalesConTodas = new List<dynamic>
            {
                new { Id = -1, Nombre = "Todas" }
            };
            sucursalesConTodas.AddRange(sucursales.Select(s => new { s.Id, s.Nombre } as dynamic));
            cmbSucursalConsulta.DataSource = sucursalesConTodas;
            cmbSucursalConsulta.DisplayMember = "Nombre";
            cmbSucursalConsulta.ValueMember = "Id";
            cmbSucursalConsulta.SelectedIndex = 0; // Seleccionar "Todas" por defecto
        }

        private void CargarDatos()
        {
            dgvProductos.DataSource = null;
            var productos = _controller.ObtenerTodos();
            dgvProductos.DataSource = productos.Select(p => new
            {
                p.Id,
                p.Codigo,
                p.Nombre,
                p.Descripcion,
                Categoria = p.Categoria?.Nombre ?? "",
                Precio = p.Precio,
                Stock = p.Stock,
                Sucursal = p.Sucursal?.Nombre ?? ""
            }).ToList();
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
            btnLimpiar.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnCrear_Click(object sender, EventArgs e)
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

            // Guardar siempre crea nuevo, ignorando cualquier selección
            if (_controller.Crear(producto))
            {
                MessageBox.Show("Producto creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al crear el producto. Verifique que el código no esté duplicado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarDatos())
                return;

            var producto = new Producto
            {
                Id = _productoSeleccionado.Id,
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                CategoriaId = (int)cmbCategoria.SelectedValue,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                SucursalId = (int)cmbSucursal.SelectedValue
            };

            if (_controller.Actualizar(producto))
            {
                MessageBox.Show("Producto actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al actualizar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                // Obtener el ID del objeto anónimo
                var selectedRow = dgvProductos.SelectedRows[0].DataBoundItem;
                var idProperty = selectedRow.GetType().GetProperty("Id");
                if (idProperty != null)
                {
                    int productoId = (int)idProperty.GetValue(selectedRow)!;
                    _productoSeleccionado = _controller.ObtenerPorId(productoId);
                    if (_productoSeleccionado != null)
                    {
                        txtCodigo.Text = _productoSeleccionado.Codigo;
                        txtNombre.Text = _productoSeleccionado.Nombre;
                        txtDescripcion.Text = _productoSeleccionado.Descripcion ?? "";
                        txtPrecio.Text = _productoSeleccionado.Precio.ToString();
                        txtStock.Text = _productoSeleccionado.Stock.ToString();
                        cmbCategoria.SelectedValue = _productoSeleccionado.CategoriaId;
                        cmbSucursal.SelectedValue = _productoSeleccionado.SucursalId;
                    }
                    btnActualizar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnLimpiar.Enabled = true;
                }
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cmbSucursalConsulta.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una sucursal.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedId = (int)cmbSucursalConsulta.SelectedValue;
            int? sucursalId = selectedId == -1 ? null : selectedId; // -1 significa "Todas"
            string? nombre = string.IsNullOrWhiteSpace(txtNombreConsulta.Text) ? null : txtNombreConsulta.Text.Trim();

            dgvProductos.DataSource = null;
            var productos = _controller.ConsultarDisponibilidad(sucursalId, nombre);
            dgvProductos.DataSource = productos.Select(p => new
            {
                p.Id,
                p.Codigo,
                p.Nombre,
                p.Descripcion,
                Categoria = p.Categoria?.Nombre ?? "",
                Precio = p.Precio,
                Stock = p.Stock,
                Sucursal = p.Sucursal?.Nombre ?? ""
            }).ToList();
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

