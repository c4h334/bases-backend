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
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductosController(AppDbContext context) { _context = context; }

        [HttpGet] public async Task<ActionResult<IEnumerable<Producto>>> GetProductos() => await _context.Productos.ToListAsync();
        [HttpGet("{id}")] public async Task<ActionResult<Producto>> GetProducto(int id) { var x = await _context.Productos.FindAsync(id); return x == null ? NotFound() : x; }
        [HttpPost] public async Task<ActionResult<Producto>> PostProducto(Producto x) { _context.Productos.Add(x); await _context.SaveChangesAsync(); return CreatedAtAction(nameof(GetProducto), new { id = x.IdProducto }, x); }
        [HttpPut("{id}")] public async Task<IActionResult> PutProducto(int id, Producto x) { if (id != x.IdProducto) return BadRequest(); _context.Entry(x).State = EntityState.Modified; await _context.SaveChangesAsync(); return NoContent(); }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            try {
                var x = await _context.Productos.FindAsync(id);
                if (x == null) return NotFound();
                _context.Productos.Remove(x);
                await _context.SaveChangesAsync();
                return NoContent();
            } catch (DbUpdateException) { 
                return BadRequest(new { message = "No se pueden eliminar productos que tengan movimientos asociados." }); 
            }
        }

        [HttpGet("{id}/alerta-stock")]
        public async Task<IActionResult> GetAlertaStock(int id, [FromServices] BasesBackend.Infrastructure.Respositories.IProductoRepository repo)
        {
            try {
                var estadoAlerta = await repo.VerificarAlertaStockAsync(id);
                return Ok(new { idProducto = id, estado = estadoAlerta });
            } catch (System.Exception ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpGet("monitoreo")]
        public async Task<IActionResult> GetMonitoreo()
        {
            var monitoreo = await _context.Productos.Select(p => new {
                p.IdProducto, p.Codigo, p.Nombre, p.Bodega, p.Pasillo, p.Estante, p.CantidadActual, p.StockCritico,
                UltimoIngreso = _context.Set<Recepcion>()
                    .Where(r => _context.Set<DetalleRecepcion>().Any(dr => dr.IdRecepcion == r.IdRecepcion && dr.IdProducto == p.IdProducto))
                    .Max(r => (System.DateTime?)r.FechaRecepcion),
                UltimoDespacho = _context.Set<Despacho>()
                    .Where(d => _context.Set<DetalleDespacho>().Any(dd => dd.IdDespacho == d.IdDespacho && dd.IdProducto == p.IdProducto))
                    .Max(d => (System.DateTime?)d.FechaDespacho)
            }).ToListAsync();
            return Ok(monitoreo);
        }
    }
}
