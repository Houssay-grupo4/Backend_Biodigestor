using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Models
{
    public class MantenimientoContext : DbContext
    {
         public MantenimientoContext(DbContextOptions<MantenimientoContext> options) : base(options)
        {
        }

        public DbSet<Mantenimiento> Mantenimiento { get; set; }

        public DbSet<BiodigestorClass> Biodigestor { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Mantenimiento>().ToTable("Mantenimientos");
            modelBuilder.Entity<Mantenimiento>().HasIndex(mantenimiento => mantenimiento.IdMantenimiento).IsUnique();
            modelBuilder.Entity<BiodigestorClass>().ToTable("Biodigestores"); // Notar que he cambiado "Biodigestor" por "Biodigestores"
            modelBuilder.Entity<BiodigestorClass>().Property(bc => bc.NombreBiodigestor).HasColumnName("NombreBiodigestor");
        }
    }
}