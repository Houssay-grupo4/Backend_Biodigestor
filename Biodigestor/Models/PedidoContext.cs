using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Models
{
    public class PedidoContext : DbContext
    {
        public PedidoContext(DbContextOptions<PedidoContext> options) : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pedido>().ToTable("Pedidos");  // Es para configurar que se use la misma tabla
            modelBuilder.Entity<Pedido>().HasIndex(pedido => pedido.IdPedido).IsUnique();
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
        }
    }
}
