using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechStore.Entidades
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Codigo { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public virtual Sucursal Sucursal { get; set; } = null!;

        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; } = new List<DetalleVenta>();
    }
}

