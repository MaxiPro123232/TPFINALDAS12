using TechStore.Controladores;
using TechStore.Entidades;
using TechStore.Modelo;
using System;
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
        private bool _cargandoDatos = false; // Bandera para evitar que SelectionChanged se ejecute durante la carga

        public FormGestionProductos()
        {
            InitializeComponent();
            _context = new TechStoreDbContext();
            _controller = new ProductoController();
            _categoriaController = new CategoriaController();
            _sucursalController = new SucursalController();
            CargarCombos(); // Cargar combos primero
            CargarDatos(); // Luego cargar datos
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

        // Carga todos los productos en el DataGridView. Transforma entidades a objetos anónimos para mostrar solo datos necesarios.
        private void CargarDatos()
        {
            _cargandoDatos = true;
            
            try
            {
                dgvProductos.ClearSelection();
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
                
                // Asegurar que no haya selección después de cargar
                dgvProductos.ClearSelection();
                LimpiarFormulario();
            }
            finally
            {
                _cargandoDatos = false; // Desactivar bandera
            }
        }

        private void LimpiarFormulario()
        {
            _productoSeleccionado = null;
            
            // Limpiar selección del DataGridView
            if (dgvProductos.SelectedRows.Count > 0)
            {
                dgvProductos.ClearSelection();
            }
            
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            
            if (cmbCategoria.Items.Count > 0)
            {
                cmbCategoria.SelectedIndex = -1;
            }
            
            if (cmbSucursal.Items.Count > 0)
            {
                cmbSucursal.SelectedIndex = -1;
            }
            
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
            try
            {
                if (_controller.Crear(producto))
                {
                    MessageBox.Show("Producto creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al crear el producto. Verifique que el código no esté duplicado y que todos los campos requeridos estén completos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            try
            {
                if (_controller.Actualizar(producto))
                {
                    MessageBox.Show("Producto actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el producto. Verifique que el código no esté duplicado y que todos los campos requeridos estén completos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionado == null)
                return;

            if (MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (_controller.Eliminar(_productoSeleccionado.Id))
                    {
                        MessageBox.Show("Producto eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el producto. Verifique que no tenga ventas asociadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            // No procesar si estamos cargando datos
            if (_cargandoDatos)
                return;
            
            // No procesar si no hay selección
            if (dgvProductos.SelectedRows.Count == 0)
            {
                LimpiarFormulario();
                return;
            }
            
            try
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
                        
                        if (cmbCategoria.Items.Count > 0)
                        {
                            cmbCategoria.SelectedValue = _productoSeleccionado.CategoriaId;
                        }
                        
                        if (cmbSucursal.Items.Count > 0)
                        {
                            cmbSucursal.SelectedValue = _productoSeleccionado.SucursalId;
                        }
                    }
                    btnActualizar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnLimpiar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                // Si hay error al cargar, limpiar formulario
                System.Diagnostics.Debug.WriteLine($"Error en SelectionChanged: {ex.Message}");
                LimpiarFormulario();
            }
        }

        // Consulta productos disponibles filtrados por sucursal y/o nombre. Muestra resultados en el DataGridView.
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cmbSucursalConsulta.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una sucursal.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _cargandoDatos = true; // Activar bandera para evitar que SelectionChanged se ejecute
            
            try
            {
                int selectedId = (int)cmbSucursalConsulta.SelectedValue;
                int? sucursalId = selectedId == -1 ? null : selectedId; // -1 significa "Todas"
                string? nombre = string.IsNullOrWhiteSpace(txtNombreConsulta.Text) ? null : txtNombreConsulta.Text.Trim();

                dgvProductos.ClearSelection();
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
                
                dgvProductos.ClearSelection();
                LimpiarFormulario();
            }
            finally
            {
                _cargandoDatos = false; // Desactivar bandera
            }
        }

        // Valida que los campos requeridos estén completos y en formato correcto. Retorna true si es válido, false si no.
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

