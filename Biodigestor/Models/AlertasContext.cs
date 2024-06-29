using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Models
{
    public class AlertasContext : DbContext
    {
        public AlertasContext(DbContextOptions<AlertasContext> options) : base(options)
        {
        }

        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<BiodigestorClass> Biodigestores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Alerta>().ToTable("Alertas");  // Asegurarse de que Provisiones usa su propia tabla
            modelBuilder.Entity<Alerta>().HasIndex(alerta => alerta.IdAlerta).IsUnique();

            // Configurar la entidad Cliente para usar la misma tabla
            modelBuilder.Entity<BiodigestorClass>().ToTable("Biodigestores");
        }
    }
}
