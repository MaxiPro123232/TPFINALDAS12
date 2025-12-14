using System.ComponentModel.DataAnnotations;

namespace TechStore.Entidades
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}

