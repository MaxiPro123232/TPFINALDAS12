using TechStore.Controladores;
using TechStore.Entidades;
using TechStore.Modelo;
using System.Linq;
using System.Reflection;

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
            _controller = new ClienteController();
            CargarCombos();
            CargarDatos();
        }

        private void CargarCombos()
        {
            cmbTipoCliente.DataSource = Enum.GetValues(typeof(TipoCliente));
        }

        private void CargarDatos()
        {
            dgvClientes.DataSource = null;
            var clientes = _controller.ObtenerTodos();
            dgvClientes.DataSource = clientes.Select(c => new
            {
                c.Id,
                c.Codigo,
                c.Nombre,
                c.Apellido,
                c.Direccion,
                c.Telefono,
                c.Email,
                TipoCliente = c.TipoCliente.ToString(),
                c.Descuento,
                c.SaldoCuentaCorriente,
                Ventas = c.Ventas?.Count ?? 0
            }).ToList();
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
            if (cmbTipoCliente.Items.Count > 0)
            {
                cmbTipoCliente.SelectedIndex = 0;
            }
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnLimpiar.Enabled = true;
            btnHistorial.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnCrear_Click(object sender, EventArgs e)
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
                TipoCliente = (TipoCliente)cmbTipoCliente.SelectedItem!,
                Descuento = decimal.TryParse(txtDescuento.Text, out decimal desc) ? desc : 0
            };

            // Guardar siempre crea nuevo, ignorando cualquier selección
            if (_controller.Crear(cliente))
            {
                MessageBox.Show("Cliente creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al crear el cliente. Verifique que el código no esté duplicado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarDatos())
                return;

            var cliente = new Cliente
            {
                Id = _clienteSeleccionado.Id,
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = string.IsNullOrWhiteSpace(txtApellido.Text) ? null : txtApellido.Text.Trim(),
                Direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text.Trim(),
                Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                TipoCliente = (TipoCliente)cmbTipoCliente.SelectedItem!,
                Descuento = decimal.TryParse(txtDescuento.Text, out decimal desc) ? desc : 0
            };

            if (_controller.Actualizar(cliente))
            {
                MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                // Obtener el ID del objeto anónimo
                var selectedRow = dgvClientes.SelectedRows[0].DataBoundItem;
                var idProperty = selectedRow.GetType().GetProperty("Id");
                if (idProperty != null)
                {
                    int clienteId = (int)idProperty.GetValue(selectedRow)!;
                    _clienteSeleccionado = _controller.ObtenerPorId(clienteId);
                    if (_clienteSeleccionado != null)
                    {
                        txtCodigo.Text = _clienteSeleccionado.Codigo;
                        txtNombre.Text = _clienteSeleccionado.Nombre;
                        txtApellido.Text = _clienteSeleccionado.Apellido ?? "";
                        txtDireccion.Text = _clienteSeleccionado.Direccion ?? "";
                        txtTelefono.Text = _clienteSeleccionado.Telefono ?? "";
                        txtEmail.Text = _clienteSeleccionado.Email ?? "";
                        txtDescuento.Text = _clienteSeleccionado.Descuento.ToString();
                        cmbTipoCliente.SelectedItem = _clienteSeleccionado.TipoCliente;
                    }
                    btnActualizar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnLimpiar.Enabled = true;
                    btnHistorial.Enabled = true;
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

