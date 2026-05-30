using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasesBackend.Infrastructure;
using BasesBackend.Domain.Entities;

namespace BasesBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesDespachoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DetallesDespachoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleDespacho>> GetDetalleDespacho(int id)
        {
            var detalle = await _context.DetallesDespacho.FindAsync(id);
            if (detalle == null) return NotFound();
            return detalle;
        }

        [HttpGet("Despacho/{despachoId}")]
        public async Task<ActionResult<IEnumerable<DetalleDespacho>>> GetDetallesPorDespacho(int despachoId)
        {
            return await _context.DetallesDespacho.Include(d => d.Producto).Where(d => d.IdDespacho == despachoId).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<DetalleDespacho>> PostDetalleDespacho(DetalleDespacho detalle)
        {
            _context.DetallesDespacho.Add(detalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDetalleDespacho), new { id = detalle.IdDetalle }, detalle);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleDespacho(int id)
        {
            var detalle = await _context.DetallesDespacho.FindAsync(id);
            if (detalle == null) return NotFound();
            _context.DetallesDespacho.Remove(detalle);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}