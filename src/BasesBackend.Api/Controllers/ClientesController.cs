using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasesBackend.Infrastructure;
using BasesBackend.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BasesBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClientesController(AppDbContext context) { _context = context; }

        [HttpGet] public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes() => await _context.Clientes.ToListAsync();
        [HttpGet("{id}")] public async Task<ActionResult<Cliente>> GetCliente(int id) { var x = await _context.Clientes.FindAsync(id); return x == null ? NotFound() : x; }
        [HttpPost] public async Task<ActionResult<Cliente>> PostCliente(Cliente x) { _context.Clientes.Add(x); await _context.SaveChangesAsync(); return CreatedAtAction(nameof(GetCliente), new { id = x.IdCliente }, x); }
        [HttpPut("{id}")] public async Task<IActionResult> PutCliente(int id, Cliente x) { if (id != x.IdCliente) return BadRequest(); _context.Entry(x).State = EntityState.Modified; await _context.SaveChangesAsync(); return NoContent(); }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try {
                var x = await _context.Clientes.FindAsync(id);
                if (x == null) return NotFound();
                _context.Clientes.Remove(x);
                await _context.SaveChangesAsync();
                return NoContent();
            } catch (DbUpdateException) { 
                return BadRequest(new { message = "No se pueden eliminar clientes que tengan movimientos asociados." }); 
            }
        }
    }
}
