using Biodigestor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biodigestor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutputGasController : ControllerBase
    {
        private readonly OutputGasContext _context;

        public OutputGasController(OutputGasContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearOutputGas(OutputGas outputGas)
        {
            await _context.OutputGases.AddAsync(outputGas);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<OutputGas>>> ListaOutputGases()
        {
            var outputGases = await _context.OutputGases.Include(og => og.BiodigestorClass).ToListAsync();

            return Ok(outputGases);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerOutputGas(int id)
        {
            var outputGas = await _context.OutputGases.Include(og => og.BiodigestorClass).FirstOrDefaultAsync(og => og.IdOutput == id);

            if (outputGas == null)
            {
                return NotFound();
            }

            return Ok(outputGas);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarOutputGas(int id, OutputGas outputGas)
        {
            var outputGasExistente = await _context.OutputGases.FindAsync(id);

            if (outputGasExistente == null)
            {
                return NotFound();
            }

            outputGasExistente.FechaSalida = outputGas.FechaSalida;
            outputGasExistente.CantidadGasSalida = outputGas.CantidadGasSalida;
            outputGasExistente.IdBiodigestor = outputGas.IdBiodigestor;
            outputGasExistente.BiodigestorClass = outputGas.BiodigestorClass;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarOutputGas(int id)
        {
            var outputGasBorrar = await _context.OutputGases.FindAsync(id);

            if (outputGasBorrar == null)
            {
                return NotFound();
            }

            _context.OutputGases.Remove(outputGasBorrar);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
