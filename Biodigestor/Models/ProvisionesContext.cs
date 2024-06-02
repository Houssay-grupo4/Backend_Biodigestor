using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Models
{
    public class ProvisionesContext : DbContext
    {
        public ProvisionesContext(DbContextOptions<ProvisionesContext> options) : base(options)
        {
        }

        public DbSet<Provision> Provisiones { get; set; }
        public DbSet<Cliente> Clientes { get; set; }  // Incluir la entidad Cliente

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Provision>().ToTable("Provisiones");  // Asegurarse de que Provisiones usa su propia tabla
            modelBuilder.Entity<Provision>().HasIndex(provision => provision.IdProvision).IsUnique();

            // Configurar la entidad Cliente para usar la misma tabla
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
        }
    }
}
