using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasesBackend.Infrastructure;
using BasesBackend.Domain.Entities;

namespace BasesBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RecepcionesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recepcion>>> GetRecepciones()
        {
            return await _context.Recepciones.Include(r => r.Cliente).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recepcion>> GetRecepcion(int id)
        {
            var recepcion = await _context.Recepciones.Include(r => r.Cliente).FirstOrDefaultAsync(r => r.IdRecepcion == id);
            if (recepcion == null) return NotFound();
            return recepcion;
        }

        [HttpPost]
        public async Task<ActionResult<Recepcion>> PostRecepcion(Recepcion recepcion)
        {
            _context.Recepciones.Add(recepcion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRecepcion), new { id = recepcion.IdRecepcion }, recepcion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecepcion(int id, Recepcion recepcion)
        {
            if (id != recepcion.IdRecepcion) return BadRequest();
            _context.Entry(recepcion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecepcion(int id)
        {
            var recepcion = await _context.Recepciones.FindAsync(id);
            if (recepcion == null) return NotFound();
            _context.Recepciones.Remove(recepcion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}