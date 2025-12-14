using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechStore.Entidades
{
    public enum MetodoPago
    {
        Efectivo = 1,
        Tarjeta = 2,
        Transferencia = 3
    }

    public class Venta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroFactura { get; set; } = string.Empty;

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;

        [Required]
        public int VendedorId { get; set; }

        [ForeignKey("VendedorId")]
        public virtual Vendedor Vendedor { get; set; } = null!;

        [Required]
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public virtual Sucursal Sucursal { get; set; } = null!;

        [Required]
        public MetodoPago MetodoPago { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Descuento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; } = new List<DetalleVenta>();
    }
}

