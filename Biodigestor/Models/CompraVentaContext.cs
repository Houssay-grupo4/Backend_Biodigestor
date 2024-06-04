using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Models
{
    public class CompraVentaContext : DbContext
    {
        public CompraVentaContext(DbContextOptions<CompraVentaContext> options) : base(options)
        {
        }

        public DbSet<CompraVenta> CompraVenta { get; set; }
        public DbSet<Cliente> Clientes { get; set; }  // Incluir la entidad Cliente

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CompraVenta>().ToTable("CompraVenta");
            modelBuilder.Entity<CompraVenta>().HasIndex(CompraVenta => CompraVenta.IdCompraVenta).IsUnique();

            // Configurar la entidad Cliente para usar la misma tabla
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
        }
    }
}