using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Models
{
    public class TemperaturaContext : DbContext
    {
        public TemperaturaContext(DbContextOptions<TemperaturaContext> options) : base(options)
        {
        }

        public DbSet<Temperatura> Temperatura { get; set; }
        public DbSet<BiodigestorClass> Biodigestor { get; set; }  // Incluir la entidad Cliente

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Temperatura>().ToTable("Temperatura");  
            modelBuilder.Entity<Temperatura>().HasIndex(temperatura => temperatura.IdTemperatura).IsUnique();

            // Configurar la entidad Cliente para usar la misma tabla
            modelBuilder.Entity<BiodigestorClass>().ToTable("Biodigestor");
        }
    }
}
