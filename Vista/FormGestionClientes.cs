using TechStore.Controladores;
using TechStore.Entidades;
using TechStore.Modelo;

namespace TechStore.Vistas
{
    public partial class FormGestionClientes : Form
    {
        private TechStoreDbContext _context;
        private ClienteController _controller;
        private Cliente? _clienteSeleccionado;

        public FormGestionClientes()
        {
            InitializeComponent();
            _context = new TechStoreDbContext();
            _controller = new ClienteController(_context);
            CargarDatos();
            CargarCombos();
        }

        private void CargarCombos()
        {
            cmbTipoCliente.DataSource = Enum.GetValues(typeof(TipoCliente));
        }

        private void CargarDatos()
        {
            dgvClientes.DataSource = _controller.ObtenerTodos();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _clienteSeleccionado = null;
            txtCodigo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDescuento.Clear();
            cmbTipoCliente.SelectedIndex = 0;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = true;
            btnHistorial.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            var cliente = new Cliente
            {
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = string.IsNullOrWhiteSpace(txtApellido.Text) ? null : txtApellido.Text.Trim(),
                Direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text.Trim(),
                Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                TipoCliente = (TipoCliente)cmbTipoCliente.SelectedValue,
                Descuento = decimal.TryParse(txtDescuento.Text, out decimal desc) ? desc : 0
            };

            if (_clienteSeleccionado == null)
            {
                if (_controller.Crear(cliente))
                {
                    MessageBox.Show("Cliente creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al crear el cliente. Verifique que el código no esté duplicado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                cliente.Id = _clienteSeleccionado.Id;
                if (_controller.Actualizar(cliente))
                {
                    MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null)
                return;

            txtCodigo.Text = _clienteSeleccionado.Codigo;
            txtNombre.Text = _clienteSeleccionado.Nombre;
            txtApellido.Text = _clienteSeleccionado.Apellido ?? "";
            txtDireccion.Text = _clienteSeleccionado.Direccion ?? "";
            txtTelefono.Text = _clienteSeleccionado.Telefono ?? "";
            txtEmail.Text = _clienteSeleccionado.Email ?? "";
            txtDescuento.Text = _clienteSeleccionado.Descuento.ToString();
            cmbTipoCliente.SelectedValue = _clienteSeleccionado.TipoCliente;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null)
                return;

            if (MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_controller.Eliminar(_clienteSeleccionado.Id))
                {
                    MessageBox.Show("Cliente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el cliente. Verifique que no tenga ventas asociadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null)
                return;

            var historial = _controller.ObtenerHistorialCompras(_clienteSeleccionado.Id);
            var form = new FormHistorialCompras(historial, _clienteSeleccionado.Nombre);
            form.ShowDialog();
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                _clienteSeleccionado = (Cliente)dgvClientes.SelectedRows[0].DataBoundItem;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                btnNuevo.Enabled = true;
                btnHistorial.Enabled = true;
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

            if (!string.IsNullOrWhiteSpace(txtDescuento.Text) && !decimal.TryParse(txtDescuento.Text, out _))
            {
                MessageBox.Show("El descuento debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

