using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasesBackend.Infrastructure;
using BasesBackend.Domain.Entities;

namespace BasesBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesRecepcionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DetallesRecepcionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleRecepcion>>> GetDetallesRecepcion()
        {
            return await _context.DetallesRecepcion
                .Include(d => d.Recepcion)
                .Include(d => d.Producto)
                .ToListAsync();
        }

        // Endpoint agregado para poder referenciarlo en el POST
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleRecepcion>> GetDetalleRecepcion(int id)
        {
            var detalle = await _context.DetallesRecepcion
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(d => d.IdDetalleRecepcion == id);

            if (detalle == null) return NotFound();
            return detalle;
        }

        [HttpGet("Recepcion/{recepcionId}")]
        public async Task<ActionResult<IEnumerable<DetalleRecepcion>>> GetDetallesPorRecepcion(int recepcionId)
        {
            return await _context.DetallesRecepcion
                .Include(d => d.Producto)
                .Where(d => d.IdRecepcion == recepcionId)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<DetalleRecepcion>> PostDetalleRecepcion(DetalleRecepcion detalleRecepcion)
        {
            _context.DetallesRecepcion.Add(detalleRecepcion);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetDetalleRecepcion), new { id = detalleRecepcion.IdDetalleRecepcion }, detalleRecepcion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleRecepcion(int id)
        {
            var detalle = await _context.DetallesRecepcion.FindAsync(id);
            if (detalle == null) return NotFound();
            _context.DetallesRecepcion.Remove(detalle);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}