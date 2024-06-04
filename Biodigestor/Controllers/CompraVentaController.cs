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
    public class CompraVentaController : ControllerBase
    {
        private readonly CompraVentaContext _context;

        public CompraVentaController(CompraVentaContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearCompraVenta(CompraVenta compraVenta)
        {
            await _context.CompraVenta.AddAsync(compraVenta);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<CompraVenta>>> ListaCompraVentas()
        {
            var compraVentas = await _context.CompraVenta.Include(cv => cv.Cliente).ToListAsync();

            return Ok(compraVentas);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerCompraVenta(int id)
        {
            var compraVenta = await _context.CompraVenta.Include(cv => cv.Cliente).FirstOrDefaultAsync(cv => cv.IdCompraVenta == id);

            if (compraVenta == null)
            {
                return NotFound();
            }

            return Ok(compraVenta);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarCompraVenta(int id, CompraVenta compraVenta)
        {
            var compraVentaExistente = await _context.CompraVenta.FindAsync(id);

            if (compraVentaExistente == null)
            {
                return NotFound();
            }

            compraVentaExistente.FechaTransaccion = compraVenta.FechaTransaccion;
            compraVentaExistente.Precio = compraVenta.Precio;
            compraVentaExistente.IdCliente = compraVenta.IdCliente;
            compraVentaExistente.Cliente = compraVenta.Cliente;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarCompraVenta(int id)
        {
            var compraVentaBorrar = await _context.CompraVenta.FindAsync(id);

            if (compraVentaBorrar == null)
            {
                return NotFound();
            }

            _context.CompraVenta.Remove(compraVentaBorrar);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}