using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechStore.Entidades
{
    public class Sucursal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Telefono { get; set; }

        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}

