using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biodigestor.Models
{
    public class Provision
    {
        [Key]
        [Column("IdProvision")]
        public int IdProvision { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaProvision { get; set; }

        public int CantidadGas { get; set; }

        public string Descripcion { get; set; } = null!;

        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; } = null!;
    }
}
