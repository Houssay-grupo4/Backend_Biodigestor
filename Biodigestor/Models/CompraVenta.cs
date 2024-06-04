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

        [Column(TypeName = "decimal(18, 2)")]
        [DisplayFormat(DataFormatString = "{0 : C2}")]
        public decimal Precio { get; set; }
        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; } = null!;
    }
}