using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasesBackend.Infrastructure;
using BasesBackend.Domain.Entities;

namespace BasesBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritosDespachoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarritosDespachoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoDespacho>> GetCarrito(int id)
        {
            var carrito = await _context.CarritosDespacho.FindAsync(id);
            if (carrito == null) return NotFound();
            return carrito;
        }

        [HttpGet("Despacho/{despachoId}")]
        public async Task<ActionResult<IEnumerable<CarritoDespacho>>> GetCarritoPorDespacho(int despachoId)
        {
            return await _context.CarritosDespacho.Include(c => c.Producto).Where(c => c.IdDespacho == despachoId).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<CarritoDespacho>> PostCarrito(CarritoDespacho carrito)
        {
            _context.CarritosDespacho.Add(carrito);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCarrito), new { id = carrito.IdCarrito }, carrito);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrito(int id, CarritoDespacho carrito)
        {
            if (id != carrito.IdCarrito) return BadRequest();
            _context.Entry(carrito).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrito(int id)
        {
            var carrito = await _context.CarritosDespacho.FindAsync(id);
            if (carrito == null) return NotFound();
            _context.CarritosDespacho.Remove(carrito);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}