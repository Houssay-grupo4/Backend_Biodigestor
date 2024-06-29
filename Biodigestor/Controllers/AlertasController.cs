using Biodigestor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertasController : ControllerBase
    {
        private readonly AlertasContext _alertasContext;

        public AlertasController(AlertasContext alertasContext)
        {
            _alertasContext = alertasContext;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Alerta>>> ListaAlertas()
        {
            var alertas = await _alertasContext.Alertas.Include(biodigestor => biodigestor.Biodigestor).ToListAsync();

            return Ok(alertas);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerAlerta(int id)
        {
            Alerta alerta = await _alertasContext.Alertas.FindAsync(id);

            if (alerta == null)
            {
                return NotFound();
            }

            return Ok(alerta);
        }

    }
}
