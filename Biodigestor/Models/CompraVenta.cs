using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biodigestor.Models
{
    public class CompraVenta
    {
        [Key]
        [Column("IdCompraVenta")]
        public int IdCompraVenta { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaTransaccion { get; set; }
        public decimal Precio { get; set; }
        public string NombreCliente { get; set; } = null!;
        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; } = null!;
    }
}