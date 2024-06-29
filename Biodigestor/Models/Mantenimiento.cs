using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Biodigestor.Models
{
    public class Mantenimiento
    {
          [System.ComponentModel.DataAnnotations.Key]
        [Column("IdMantenimiento")]

        public int IdMantenimiento { get; set; }

       

        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DatefechaMantenimiento { get; set; }

        public string? Observaciones {  get; set; }

        public int IdBiodigestor {  get; set; }

        [ForeignKey("IdBiodigestor")]
        public BiodigestorClass Biodigestor { get; set; } = null!;
       
    }
        
    }
