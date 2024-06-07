using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Models
{
    public class BiodigestorContext : DbContext
    {

        public BiodigestorContext(DbContextOptions<BiodigestorContext> options) : base(options)
        {
        }

        public DbSet<BiodigestorClass> Biodigestores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BiodigestorClass>().ToTable("Biodigestores");  // Es para configurar que se use la misma tabla
            modelBuilder.Entity<BiodigestorClass>().HasIndex(biodigestor => biodigestor.IdBiodiestor).IsUnique();
        }

    }
}
