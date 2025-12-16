using TechStore.Controladores;
using TechStore.Entidades;
using TechStore.Modelo;

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
            _controller = new SucursalController(_context);
            CargarDatos();
        }

        private void CargarDatos()
        {
            dgvSucursales.DataSource = null;
            dgvSucursales.DataSource = _controller.ObtenerTodas();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _sucursalSeleccionada = null;
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            btnActualizar.Enabled = false;
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

            if (_sucursalSeleccionada == null)
            {
                if (_controller.Crear(sucursal))
                {
                    MessageBox.Show("Sucursal creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al crear la sucursal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                sucursal.Id = _sucursalSeleccionada.Id;
                if (_controller.Actualizar(sucursal))
                {
                    MessageBox.Show("Sucursal actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la sucursal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_sucursalSeleccionada == null)
                return;

            txtNombre.Text = _sucursalSeleccionada.Nombre;
            txtDireccion.Text = _sucursalSeleccionada.Direccion;
            txtTelefono.Text = _sucursalSeleccionada.Telefono ?? "";
            btnActualizar.Enabled = false;
            btnNuevo.Enabled = true;
        }

        private void dgvSucursales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSucursales.SelectedRows.Count > 0)
            {
                _sucursalSeleccionada = (Sucursal)dgvSucursales.SelectedRows[0].DataBoundItem;
                btnActualizar.Enabled = true;
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

