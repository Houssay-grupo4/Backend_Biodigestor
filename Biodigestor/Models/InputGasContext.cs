
using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Models
{
    public class InputGasContext : DbContext
    {
        public InputGasContext(DbContextOptions<InputGasContext> options) : base(options)
        {
        }
        public DbSet<InputGas> InputGases { get; set; }
        public DbSet<BiodigestorClass> Biodigestores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InputGas>().ToTable("InputGases"); 
            modelBuilder.Entity<InputGas>().HasIndex(inputgas=> inputgas.IdInputGas).IsUnique();

            modelBuilder.Entity<BiodigestorClass>().ToTable("Biodigestores");

            
                
        }
    }
}



