using TechStore.Controladores;
using TechStore.Entidades;
using TechStore.Modelo;
using System.Linq;
using System.Reflection;

namespace TechStore.Vistas
{
    public partial class FormGestionVendedores : Form
    {
        private TechStoreDbContext _context;
        private VendedorController _controller;
        private SucursalController _sucursalController;
        private Vendedor? _vendedorSeleccionado;

        public FormGestionVendedores()
        {
            InitializeComponent();
            _context = new TechStoreDbContext();
            _controller = new VendedorController(_context);
            _sucursalController = new SucursalController(_context);
            CargarDatos();
            CargarCombos();
        }

        private void CargarCombos()
        {
            cmbSucursal.DataSource = null;
            cmbSucursal.DataSource = _sucursalController.ObtenerTodas();
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "Id";
        }

        private void CargarDatos()
        {
            dgvVendedores.DataSource = null;
            var vendedores = _controller.ObtenerTodos();
            dgvVendedores.DataSource = vendedores.Select(v => new
            {
                v.Id,
                v.Codigo,
                v.Nombre,
                v.Apellido,
                v.Telefono,
                Sucursal = v.Sucursal?.Nombre ?? "",
                Ventas = v.Ventas?.Count ?? 0
            }).ToList();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _vendedorSeleccionado = null;
            txtCodigo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
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

            var vendedor = new Vendedor
            {
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = string.IsNullOrWhiteSpace(txtApellido.Text) ? null : txtApellido.Text.Trim(),
                Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                SucursalId = (int)cmbSucursal.SelectedValue
            };

            // Guardar siempre crea nuevo, ignorando cualquier selección
            if (_controller.Crear(vendedor))
            {
                MessageBox.Show("Vendedor creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al crear el vendedor. Verifique que el código no esté duplicado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_vendedorSeleccionado == null)
            {
                MessageBox.Show("Seleccione un vendedor para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarDatos())
                return;

            var vendedor = new Vendedor
            {
                Id = _vendedorSeleccionado.Id,
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = string.IsNullOrWhiteSpace(txtApellido.Text) ? null : txtApellido.Text.Trim(),
                Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                SucursalId = (int)cmbSucursal.SelectedValue
            };

            if (_controller.Actualizar(vendedor))
            {
                MessageBox.Show("Vendedor actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al actualizar el vendedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_vendedorSeleccionado == null)
                return;

            if (MessageBox.Show("¿Está seguro de eliminar este vendedor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_controller.Eliminar(_vendedorSeleccionado.Id))
                {
                    MessageBox.Show("Vendedor eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el vendedor. Verifique que no tenga ventas asociadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvVendedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVendedores.SelectedRows.Count > 0)
            {
                // Obtener el ID del objeto anónimo
                var selectedRow = dgvVendedores.SelectedRows[0].DataBoundItem;
                var idProperty = selectedRow.GetType().GetProperty("Id");
                if (idProperty != null)
                {
                    int vendedorId = (int)idProperty.GetValue(selectedRow)!;
                    _vendedorSeleccionado = _controller.ObtenerPorId(vendedorId);
                    if (_vendedorSeleccionado != null)
                    {
                        txtCodigo.Text = _vendedorSeleccionado.Codigo;
                        txtNombre.Text = _vendedorSeleccionado.Nombre;
                        txtApellido.Text = _vendedorSeleccionado.Apellido ?? "";
                        txtTelefono.Text = _vendedorSeleccionado.Telefono ?? "";
                        cmbSucursal.SelectedValue = _vendedorSeleccionado.SucursalId;
                    }
                    btnActualizar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnLimpiar.Enabled = true;
                }
            }
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

