using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Models
{
    public class ClientesContext : DbContext
    {
        public ClientesContext(DbContextOptions<ClientesContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>().ToTable("Clientes");  // Es para configurar que se use la misma tabla
            modelBuilder.Entity<Cliente>().HasIndex(cliente => cliente.IdCliente).IsUnique();
        }
    }
}
