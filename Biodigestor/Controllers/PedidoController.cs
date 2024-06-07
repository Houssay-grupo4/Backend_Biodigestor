using Biodigestor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoContext _context;
        public PedidoController(PedidoContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearPedido(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Pedido>>> ListaPedido()
        {
            var pedido = await _context.Pedidos.ToListAsync();

            return Ok(pedido);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerPedido(int id)
        {
            Pedido pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }
        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarPedido(int id, Pedido pedido)
        {
            var pedidoExistente = await _context.Pedidos.FindAsync(id);

            pedidoExistente!.IdPedido = pedido.IdPedido;
            pedidoExistente!.CantidadGas = pedido.CantidadGas;
            pedidoExistente!.Cliente = pedidoExistente.Cliente;
            pedidoExistente.IdCliente = pedidoExistente.IdCliente;
            pedidoExistente.DatefechaPedido = pedidoExistente.DatefechaPedido;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarPedido(int id)
        {
            var pedidoBorrar = await _context.Pedidos.FindAsync(id);

            _context.Pedidos.Remove(pedidoBorrar!);

            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
