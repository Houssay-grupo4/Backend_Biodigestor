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

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearTemperatura(Temperatura temperatura)
        {
            await _context.Temperatura.AddAsync(temperatura);
            await _context.SaveChangesAsync();

            return Ok();
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

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarTemperatura(int id, Temperatura temperatura)
        {
            var temperaturaExistente = await _context.Temperatura.FindAsync(id);

            temperaturaExistente!.fechaTemperatura = temperatura.fechaTemperatura;
            temperaturaExistente!.nivelTemperatura = temperatura.nivelTemperatura;
            temperaturaExistente!.IdBiodigestor = temperatura.IdBiodigestor;
            temperaturaExistente!.Biodigestor = temperatura.Biodigestor;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarTemperatura(int id)
        {
            var temperaturaBorrar = await _context.Temperatura.FindAsync(id);

            _context.Temperatura.Remove(temperaturaBorrar!);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

