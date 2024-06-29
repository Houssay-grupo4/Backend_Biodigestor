using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biodigestor.Models
{
    public class OutputGas
    {
        [Key]
        [Column("IdOutput")]
        public int IdOutput { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaSalida { get; set; }

        public float CantidadGasSalida { get; set; }

        public int IdBiodigestor { get; set; }

    [ForeignKey("IdBiodigestor")]
        public BiodigestorClass BiodigestorClass { get; set; } = null!;
    }
}
