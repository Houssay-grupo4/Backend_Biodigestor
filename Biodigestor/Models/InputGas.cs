
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biodigestor.Models
{
    public class InputGas
    {
        [Key]
        [Column("IdInputGas")]
        public int IdInputGas { get; set; }

        [Required]
        [Column("CantidadGasEntrada", TypeName = "float")]
        public float CantidadGasEntrada { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column("FechaEntrada")]
        public DateTime FechaEntrada { get; set; }

        [Required]
        [Column("IdBiodigestor")]
        public int IdBiodigestor { get; set; }

        [ForeignKey("IdBiodigestor")]
        public BiodigestorClass Biodigestor { get; set; } = null!;
    }
}

