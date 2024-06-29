using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Models
{
    public class OutputGasContext : DbContext
    {
        public OutputGasContext(DbContextOptions<OutputGasContext> options) : base(options)
        {
        }

        public DbSet<OutputGas> OutputGases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OutputGas>().ToTable("OutputGases");
        }
    }
}
