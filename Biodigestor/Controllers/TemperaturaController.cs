using Biodigestor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturaController : ControllerBase
    {
        private readonly TemperaturaContext _context;

        public TemperaturaController(TemperaturaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Temperatura>>> ListaTemperaturas()
        {
            var temperaturas = await _context.Temperatura
                .Include(biodigestor => biodigestor.Biodigestor)
                .ToListAsync();

            return Ok(temperaturas);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerTemperatura(int id)
        {
            Temperatura temperatura = await _context.Temperatura.FindAsync(id);

            if (temperatura == null)
            {
                return NotFound();
            }

            return Ok(temperatura);
        }

    }
}

