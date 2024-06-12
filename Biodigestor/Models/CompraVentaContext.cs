using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Models
{
    public class CompraVentaContext : DbContext
    {
        public CompraVentaContext(DbContextOptions<CompraVentaContext> options) : base(options)
        {
        }

        public DbSet<CompraVenta> CompraVenta { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CompraVenta>().ToTable("CompraVenta");
            modelBuilder.Entity<CompraVenta>().HasIndex(CompraVenta => CompraVenta.IdCompraVenta).IsUnique();

            modelBuilder.Entity<Cliente>().ToTable("Clientes");
        }
    }
}


