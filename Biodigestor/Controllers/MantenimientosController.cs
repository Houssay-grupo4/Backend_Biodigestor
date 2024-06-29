using Biodigestor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientosController : ControllerBase
    {
        private readonly MantenimientoContext _context;
        public MantenimientosController(MantenimientoContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearMantenimiento(Mantenimiento mantenimiento)
        {
            await _context.Mantenimiento.AddAsync(mantenimiento);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Mantenimiento>>> ListaMantenimiento()
        {
            var mantenimiento = await _context.Mantenimiento.ToListAsync();

            return Ok(mantenimiento);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerMantenimiento(int id)
        {
            Mantenimiento mantenimiento = await _context.Mantenimiento.FindAsync(id);

            if (mantenimiento == null)
            {
                return NotFound();
            }

            return Ok(mantenimiento);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarMantenimiento(int id, Mantenimiento mantenimiento)
        {
            var mantenimientoExistente = await _context.Mantenimiento.FindAsync(id);

            mantenimientoExistente!.IdMantenimiento = mantenimiento.IdMantenimiento;
            mantenimientoExistente!.Observaciones = mantenimiento.Observaciones;
            mantenimientoExistente.DatefechaMantenimiento = mantenimiento.DatefechaMantenimiento;

            mantenimientoExistente.IdBiodigestor = mantenimiento.IdBiodigestor;
            mantenimientoExistente.Biodigestor = mantenimiento.Biodigestor;


            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarMantenimiento(int id)
        {
            var mantenimientoBorrar = await _context.Mantenimiento.FindAsync(id);

            _context.Mantenimiento.Remove(mantenimientoBorrar!);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
