using TechStore.Controladores;
using TechStore.Entidades;
using TechStore.Modelo;
using System.Linq;
using System.Reflection;

namespace TechStore.Vistas
{
    public partial class FormGestionSucursales : Form
    {
        private TechStoreDbContext _context;
        private SucursalController _controller;
        private Sucursal? _sucursalSeleccionada;

        public FormGestionSucursales()
        {
            InitializeComponent();
            _context = new TechStoreDbContext();
            _controller = new SucursalController();
            CargarDatos();
        }

        private void CargarDatos()
        {
            dgvSucursales.DataSource = null;
            var sucursales = _controller.ObtenerTodas();
            dgvSucursales.DataSource = sucursales.Select(s => new
            {
                s.Id,
                s.Nombre,
                s.Direccion,
                s.Telefono,
                Productos = s.Productos != null && s.Productos.Any()
                    ? string.Join(" - ", s.Productos.Select(p => p.Nombre))
                    : "",
                Ventas = s.Ventas?.Count ?? 0
            }).ToList();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _sucursalSeleccionada = null;
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
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

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("La dirección es requerida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sucursal = new Sucursal
            {
                Nombre = txtNombre.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim()
            };

            // Guardar siempre crea nuevo, ignorando cualquier selección
            if (_controller.Crear(sucursal))
            {
                MessageBox.Show("Sucursal creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al crear la sucursal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_sucursalSeleccionada == null)
            {
                MessageBox.Show("Seleccione una sucursal para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("La dirección es requerida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sucursal = new Sucursal
            {
                Id = _sucursalSeleccionada.Id,
                Nombre = txtNombre.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim()
            };

            if (_controller.Actualizar(sucursal))
            {
                MessageBox.Show("Sucursal actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al actualizar la sucursal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSucursales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSucursales.SelectedRows.Count > 0)
            {
                // Obtener el ID del objeto anónimo
                var selectedRow = dgvSucursales.SelectedRows[0].DataBoundItem;
                var idProperty = selectedRow.GetType().GetProperty("Id");
                if (idProperty != null)
                {
                    int sucursalId = (int)idProperty.GetValue(selectedRow)!;
                    _sucursalSeleccionada = _controller.ObtenerPorId(sucursalId);
                    if (_sucursalSeleccionada != null)
                    {
                        txtNombre.Text = _sucursalSeleccionada.Nombre;
                        txtDireccion.Text = _sucursalSeleccionada.Direccion;
                        txtTelefono.Text = _sucursalSeleccionada.Telefono ?? "";
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_sucursalSeleccionada == null)
                return;

            if (MessageBox.Show("¿Está seguro de eliminar esta sucursal?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_controller.Eliminar(_sucursalSeleccionada.Id))
                {
                    MessageBox.Show("Sucursal eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la sucursal. Verifique que no tenga productos o ventas asociadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

