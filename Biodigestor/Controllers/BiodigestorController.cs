using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biodigestor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biodigestor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiodigestorController : ControllerBase
    {
        private readonly BiodigestorContext _context;

        public BiodigestorController(BiodigestorContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearBiodigestor(BiodigestorClass biodigestor)
        {
            await _context.Biodigestores.AddAsync(biodigestor);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<BiodigestorClass>>> ListaBiodigestores()
        {
            var biodigestores = await _context.Biodigestores.ToListAsync();

            return Ok(biodigestores);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerBiodigestor(int id)
        {
            var biodigestor = await _context.Biodigestores.FindAsync(id);

            if (biodigestor == null)
            {
                return NotFound();
            }

            return Ok(biodigestor);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarBiodigestor(int id,BiodigestorClass biodigestor)
        {
            var biodigestorExistente = await _context.Biodigestores.FindAsync(id);

            if (biodigestorExistente == null)
            {
                return NotFound();
            }

            biodigestorExistente!.NombreBiodigestor = biodigestor.NombreBiodigestor;
            biodigestorExistente!.ModeloBiodigestor = biodigestor.ModeloBiodigestor;
            biodigestorExistente!.VolumenGas = biodigestor.VolumenGas;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarBiodigestor(int id)
        {
            var biodigestorBorrar = await _context.Biodigestores.FindAsync(id);

            if (biodigestorBorrar == null)
            {
                return NotFound();
            }

            _context.Biodigestores.Remove(biodigestorBorrar);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

