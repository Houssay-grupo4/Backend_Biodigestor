using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biodigestor.Models
{
    public class BiodigestorClass
    {
        [Key]
        [Column("IdBiodigestor")]
        public int IdBiodigestor { get; set; }
        public string NombreBiodigestor { get; set; } = null!;
        public string ModeloBiodigestor { get; set; } = null!;
        public int VolumenGas { get; set; }
    }
}
