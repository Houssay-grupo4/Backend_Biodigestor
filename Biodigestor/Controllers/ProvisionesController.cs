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

        public ProvisionesController(ProvisionesContext context, ClientesContext clientesContext)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearProvision(Provision provision)
        {
            /* Nota: Si se desea agregar un cliente ya existente en la base de datos, solamente se debe colocar el IdCliente. Caso
            contrario, se deberán completar los campos nombres y apellido del cliente, dejando ambos IdCliente en 0.*/
            Cliente clienteBuscado = await _context.Clientes.FindAsync(provision.IdCliente);

            try
            {
                if (clienteBuscado == null)
                {
                    Cliente nuevoCliente = new Cliente
                    {
                        IdCliente = provision.IdCliente,
                        Nombre = provision.Cliente.Nombre,
                        Apellido = provision.Cliente.Apellido
                    };

                    provision.Cliente = nuevoCliente;

                    await _context.Provisiones.AddAsync(provision);
                }
                else
                {
                    provision.Cliente = clienteBuscado;

                    await _context.Provisiones.AddAsync(provision);
                }

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al crear la provisión: {ex.Message}");
            }
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
            /*
            NOTA: Si se desea modificar, agregando un cliente ya existente en la base de datos, solamente se deberá colocar el valor del mismo cliente 
            en el primer atributo de IdCliente, SIN TOCAR EL OBJETO CLIENTE QUE FIGURA DEBAJO.
            En cambio, si se desea modificar una provision ya existente, agregando un nuevo cliente, los IdCliente deberán estar en 0, mientras que se deberán
            rellenar los campos Nombre y Apellido que figuran dentro del objeto Cliente.           
             */
            try
            {
                var provisionExistente = await _context.Provisiones.FindAsync(id);

                if (provisionExistente == null)
                {
                    return NotFound($"No se encontró la provisión con Id {id}");
                }

                provisionExistente.FechaProvision = provision.FechaProvision;
                provisionExistente.CantidadGas = provision.CantidadGas;
                provisionExistente.Descripcion = provision.Descripcion;


                Cliente clienteBuscado = await _context.Clientes.FindAsync(provision.IdCliente);

                if (clienteBuscado == null)
                {

                    Cliente nuevoCliente = new Cliente
                    {
                        IdCliente = provision.IdCliente,
                        Nombre = provision.Cliente.Nombre,
                        Apellido = provision.Cliente.Apellido
                    };

                    provisionExistente.Cliente = nuevoCliente;
                }
                else
                {
                    provisionExistente.Cliente = clienteBuscado;
                }

                _context.Provisiones.Update(provisionExistente);
                await _context.SaveChangesAsync();

                return Ok("Provisión actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar la provisión: {ex.Message}");
            }
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
