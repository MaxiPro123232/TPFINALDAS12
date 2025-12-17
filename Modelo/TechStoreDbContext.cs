using Microsoft.EntityFrameworkCore;
using TechStore.Entidades;

namespace TechStore.Modelo
{
    public class TechStoreDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }

        private string conexion = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TECHSTORE;Integrated Security=True;Persist Security Info=False;Pooling=False;Encrypt=False";
        
        // Configura la conexión a SQL Server LocalDB si no está ya configurada.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conexion);
            }
        }
      
        // Configura las entidades del modelo: índices únicos y comportamientos de eliminación.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating: aplica las configuraciones por defecto de Entity Framework antes de las personalizadas.
            base.OnModelCreating(modelBuilder);

            // HasIndex: define un índice para mejorar búsquedas. IsUnique: asegura que no haya valores duplicados.
            modelBuilder.Entity<Producto>()
                .HasIndex(e => e.Codigo)
                .IsUnique();

            modelBuilder.Entity<Cliente>()
                .HasIndex(e => e.Codigo)
                .IsUnique();

            modelBuilder.Entity<Vendedor>()
                .HasIndex(e => e.Codigo)
                .IsUnique();

            modelBuilder.Entity<Venta>()
                .HasIndex(e => e.NumeroFactura)
                .IsUnique();

            // OnDelete: define qué pasa cuando se elimina la entidad relacionada. Cascade = se eliminan también los detalles.
            modelBuilder.Entity<DetalleVenta>()
                .HasOne(d => d.Venta)
                .WithMany(v => v.DetalleVentas)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

