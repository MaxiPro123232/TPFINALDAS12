using TechStore.Entidades;
using System.Linq;

namespace TechStore.Vistas
{
    public partial class FormHistorialCompras : Form
    {
        public FormHistorialCompras(List<Venta> ventas, string nombreCliente)
        {
            InitializeComponent();
            lblCliente.Text = $"Historial de Compras - {nombreCliente}";
            
            // Crear objetos anónimos excluyendo Cliente y mostrando Fecha en lugar de DetalleVentas
            dgvVentas.DataSource = ventas.Select(v => new
            {
                v.Id,
                v.NumeroFactura,
                Fecha = v.Fecha,
                Vendedor = v.Vendedor?.Nombre ?? "",
                Sucursal = v.Sucursal?.Nombre ?? "",
                MetodoPago = v.MetodoPago.ToString(),
                v.Subtotal,
                v.Descuento,
                v.Total
            }).ToList();
        }
    }
}

