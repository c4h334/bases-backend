using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasesBackend.Infrastructure;
using BasesBackend.Domain.Entities;

namespace BasesBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespachosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DespachosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Despacho>>> GetDespachos()
        {
            return await _context.Despachos.Include(d => d.Cliente).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Despacho>> GetDespacho(int id)
        {
            var despacho = await _context.Despachos.Include(d => d.Cliente).FirstOrDefaultAsync(d => d.IdDespacho == id);
            if (despacho == null) return NotFound();
            return despacho;
        }

        [HttpPost]
        public async Task<ActionResult<Despacho>> PostDespacho(Despacho despacho)
        {
            _context.Despachos.Add(despacho);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDespacho), new { id = despacho.IdDespacho }, despacho);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDespacho(int id, Despacho despacho)
        {
            if (id != despacho.IdDespacho) return BadRequest();
            _context.Entry(despacho).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDespacho(int id)
        {
            var despacho = await _context.Despachos.FindAsync(id);
            if (despacho == null) return NotFound();
            _context.Despachos.Remove(despacho);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}