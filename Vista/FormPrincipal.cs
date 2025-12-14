using TechStore.Vistas;

namespace TechStore.Vistas
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            var form = new FormGestionProductos();
            form.ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            var form = new FormGestionCategorias();
            form.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            var form = new FormGestionClientes();
            form.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            var form = new FormGestionVentas();
            form.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            var form = new FormReportes();
            form.ShowDialog();
        }

        private void btnSucursales_Click(object sender, EventArgs e)
        {
            var form = new FormGestionSucursales();
            form.ShowDialog();
        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            var form = new FormGestionVendedores();
            form.ShowDialog();
        }
    }
}

