using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasesBackend.Infrastructure;
using BasesBackend.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BasesBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RecepcionesController(AppDbContext context) { _context = context; }

        [HttpGet] public async Task<ActionResult<IEnumerable<Recepcion>>> GetRecepciones() => await _context.Recepciones.Include(r => r.Cliente).ToListAsync();
        [HttpGet("{id}")] public async Task<ActionResult<Recepcion>> GetRecepcion(int id) { var x = await _context.Recepciones.Include(r => r.Cliente).FirstOrDefaultAsync(r => r.IdRecepcion == id); return x == null ? NotFound() : x; }
        [HttpPost] public async Task<ActionResult<Recepcion>> PostRecepcion(Recepcion x) { _context.Recepciones.Add(x); await _context.SaveChangesAsync(); return CreatedAtAction(nameof(GetRecepcion), new { id = x.IdRecepcion }, x); }
        [HttpPut("{id}")] public async Task<IActionResult> PutRecepcion(int id, Recepcion x) { if (id != x.IdRecepcion) return BadRequest(); _context.Entry(x).State = EntityState.Modified; await _context.SaveChangesAsync(); return NoContent(); }
        [HttpDelete("{id}")] public async Task<IActionResult> DeleteRecepcion(int id) { var x = await _context.Recepciones.FindAsync(id); if (x == null) return NotFound(); _context.Recepciones.Remove(x); await _context.SaveChangesAsync(); return NoContent(); }

        [HttpPost("registrar-sp")]
        public async Task<IActionResult> RegistrarRecepcionSP([FromServices] BasesBackend.Infrastructure.Respositories.IRecepcionRepository repo, [FromBody] System.Text.Json.JsonElement data)
        {
            try {
                var numeroLote = data.GetProperty("numeroLote").GetString();
                var usuarioAtendio = data.GetProperty("usuarioAtendio").GetString();
                var idCliente = data.GetProperty("idCliente").GetInt32();
                var idProducto = data.GetProperty("idProducto").GetInt32();
                var cantidad = data.GetProperty("cantidad").GetInt32();

                var result = await repo.RegistrarRecepcionAsync(numeroLote, usuarioAtendio, idCliente, idProducto, cantidad);
                if (result != null && result.Contains("ERROR")) return BadRequest(new { message = result });
                return Ok(new { message = result });
            } catch (System.Exception ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpGet("producto/{idProducto}")]
        public async Task<IActionResult> GetRecepcionesPorProducto(int idProducto)
        {
            var recepciones = await (from dr in _context.Set<DetalleRecepcion>()
                                     join r in _context.Set<Recepcion>() on dr.IdRecepcion equals r.IdRecepcion
                                     join c in _context.Set<Cliente>() on r.IdCliente equals c.IdCliente
                                     where dr.IdProducto == idProducto
                                     orderby r.FechaRecepcion descending
                                     select new {
                                         r.IdRecepcion, r.NumeroLote, r.FechaRecepcion, r.UsuarioAtendio,
                                         Cliente = c.Nombre, dr.Cantidad
                                     }).ToListAsync();
            return Ok(recepciones);
        }
    }
}
