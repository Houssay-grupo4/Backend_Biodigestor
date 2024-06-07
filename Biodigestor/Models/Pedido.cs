using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biodigestor.Models
{
    public class Pedido
    {
        [Key]
        [Column("IdPedido")]

        public int IdPedido { get; set; }

        public float CantidadGas {  get; set; }

        [DataType(DataType.Date)]
        public DateTime DatefechaPedido { get; set; }

        public int IdCliente {  get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; } = null!;

    }
}
