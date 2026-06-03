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
    public class DespachosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DespachosController(AppDbContext context) { _context = context; }

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<Despacho>>> GetDespachos([FromQuery] System.DateTime? fechaInicio, [FromQuery] System.DateTime? fechaFin) 
        {
            // CORRECCIÓN 1: Se suma 1 día al límite superior para evitar que la diferencia UTC-6 oculte los registros nuevos
            var fin = fechaFin ?? System.DateTime.Now.AddDays(1);
            var inicio = fechaInicio ?? System.DateTime.Now.AddDays(-7);
            
            // CORRECCIÓN 2: Restauramos el Include para que el nombre del cliente viaje en el JSON
            return await _context.Despachos
                .Include(d => d.Cliente)
                .Where(d => d.FechaDespacho >= inicio && d.FechaDespacho <= fin)
                .OrderByDescending(d => d.FechaDespacho)
                .ToListAsync();
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Despacho>> GetDespacho(int id) 
        { 
            var x = await _context.Despachos.FirstOrDefaultAsync(d => d.IdDespacho == id); 
            return x == null ? NotFound() : x; 
        }

        [HttpPost] 
        public async Task<ActionResult<Despacho>> PostDespacho(Despacho x) 
        { 
            _context.Despachos.Add(x); 
            await _context.SaveChangesAsync(); 
            return CreatedAtAction(nameof(GetDespacho), new { id = x.IdDespacho }, x); 
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> PutDespacho(int id, Despacho x) 
        { 
            if (id != x.IdDespacho) return BadRequest(); 
            _context.Entry(x).State = EntityState.Modified; 
            await _context.SaveChangesAsync(); 
            return NoContent(); 
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteDespacho(int id) 
        { 
            var x = await _context.Despachos.FindAsync(id); 
            if (x == null) return NotFound(); 
            _context.Despachos.Remove(x); 
            await _context.SaveChangesAsync(); 
            return NoContent(); 
        }

        [HttpPost("{id}/procesar-sp")]
        public async Task<IActionResult> ProcesarDespachoSP(int id, [FromServices] BasesBackend.Infrastructure.Respositories.IDespachoRepository repo, [FromBody] System.Text.Json.JsonElement data)
        {
            try {
                var idCliente = data.GetProperty("idCliente").GetInt32();
                var result = await repo.ProcesarDespachoAsync(id, idCliente);
                if (result != null && result.Contains("ERROR")) return BadRequest(new { message = result });
                return Ok(new { message = result ?? "Despacho procesado con éxito." });
            } catch (System.Exception ex) { return BadRequest(new { message = ex.Message }); }
        }
    }
}
