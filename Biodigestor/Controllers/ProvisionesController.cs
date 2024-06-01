using Biodigestor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvisionesController : ControllerBase
    {
        private readonly ProvisionesContext _context;

        public ProvisionesController(ProvisionesContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearProvision(Provision provision)
        {
            await _context.Provisiones.AddAsync(provision);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Provision>>> ListaProvisiones()
        {
            var provisiones = await _context.Provisiones.Include(cliente => cliente.Cliente).ToListAsync();

            return Ok(provisiones);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerProvision(int id)
        {
            Provision provision = await _context.Provisiones.FindAsync(id);

            if (provision == null)
            {
                return NotFound();
            }

            return Ok(provision);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarProvision(int id, Provision provision)
        {
            var provisionExistente = await _context.Provisiones.FindAsync(id);

            provisionExistente!.FechaProvision = provision.FechaProvision;
            provisionExistente!.CantidadGas = provision.CantidadGas;
            provisionExistente!.Descripcion = provision.Descripcion;
            provisionExistente!.IdCliente = provision.IdCliente;
            provisionExistente!.Cliente = provision.Cliente;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarProvision(int id)
        {
            var provisionBorrar = await _context.Provisiones.FindAsync(id);

            _context.Provisiones.Remove(provisionBorrar!);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
