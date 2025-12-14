using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechStore.Entidades
{
    public class Vendedor
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

        [StringLength(20)]
        public string? Telefono { get; set; }

        [Required]
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public virtual Sucursal Sucursal { get; set; } = null!;

        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}

