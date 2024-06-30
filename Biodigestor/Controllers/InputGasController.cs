using Biodigestor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biodigestor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputGasController : ControllerBase
    {
        private readonly InputGasContext _context;

        public InputGasController(InputGasContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearInputGas(InputGas inputGas)
        {
            await _context.InputGases.AddAsync(inputGas);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<InputGas>>> ListaInputGases()
        {
            var inputGases = await _context.InputGases.Include(ig => ig.Biodigestor).ToListAsync();
            return Ok(inputGases);
        }

        [HttpGet]
        [Route("ver/{id}")]
        public async Task<IActionResult> VerInputGas(int id)
        {
            var inputGas = await _context.InputGases.Include(ig => ig.Biodigestor).FirstOrDefaultAsync(ig => ig.IdInputGas == id);

            if (inputGas == null)
            {
                return NotFound();
            }

            return Ok(inputGas);
        }

        [HttpPut]
        [Route("editar/{id}")]
        public async Task<IActionResult> ActualizarInputGas(int id, InputGas inputGas)
        {
            var inputGasExistente = await _context.InputGases.FindAsync(id);

            if (inputGasExistente == null)
            {
                return NotFound();
            }
            inputGasExistente.IdInputGas = inputGas.IdInputGas;
            inputGasExistente.CantidadGasEntrada = inputGas.CantidadGasEntrada;
            inputGasExistente.FechaEntrada = inputGas.FechaEntrada;
            inputGasExistente.IdBiodigestor = inputGas.IdBiodigestor;
            inputGasExistente.Biodigestor = inputGas.Biodigestor;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<IActionResult> EliminarInputGas(int id)
        {
            var inputGasBorrar = await _context.InputGases.FindAsync(id);

            if (inputGasBorrar == null)
            {
                return NotFound();
            }

            _context.InputGases.Remove(inputGasBorrar);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

