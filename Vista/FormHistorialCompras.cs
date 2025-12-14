using TechStore.Entidades;

namespace TechStore.Vistas
{
    public partial class FormHistorialCompras : Form
    {
        public FormHistorialCompras(List<Venta> ventas, string nombreCliente)
        {
            InitializeComponent();
            lblCliente.Text = $"Historial de Compras - {nombreCliente}";
            dgvVentas.DataSource = ventas;
        }
    }
}

