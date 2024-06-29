using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biodigestor.Models
{
    public class Alerta
    {
        [Key]
        [Column("IdAlerta")]
        public int IdAlerta { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaHoraAlerta { get; set; }
        public String NivelSeveridad { get; set; } = null!;
        public String TituloAlerta { get; set; } = null!;
        public String DescripcionAlerta { get; set; } = null!;
        public int IdBiodigestor { get; set; }

        [ForeignKey("IdBiodigestor")]
        public BiodigestorClass Biodigestor { get; set; } = null!;
    }
}
