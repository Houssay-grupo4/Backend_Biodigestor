using Biodigestor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biodigestor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesContext _context;
        public ClientesController(ClientesContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearCliente(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Cliente>>> ListaClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();

            return Ok(clientes);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerCliente(int id)
        {
            Cliente cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarCliente(int id, Cliente cliente)
        {
            var clienteExistente = await _context.Clientes.FindAsync(id);

            clienteExistente!.Nombre = cliente.Nombre;
            clienteExistente!.Apellido = cliente.Apellido;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            var clienteBorrar = await _context.Clientes.FindAsync(id);

            _context.Clientes.Remove(clienteBorrar!);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
