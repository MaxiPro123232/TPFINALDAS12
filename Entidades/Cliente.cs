using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechStore.Entidades
{
    public enum TipoCliente
    {
        Minorista = 1,
        Mayorista = 2
    }

    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Codigo { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Apellido { get; set; }

        [StringLength(200)]
        public string? Direccion { get; set; }

        [StringLength(20)]
        public string? Telefono { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        public TipoCliente TipoCliente { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Descuento { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoCuentaCorriente { get; set; } = 0;

        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}

