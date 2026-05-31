using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasesBackend.Infrastructure;
using BasesBackend.Domain.Entities;
using BasesBackend.Dto; // Asegúrate de incluir el using del DTO

namespace BasesBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetProductos()
        {
            // Consulta cruda a MySQL para cruzar tablas y ejecutar la función SQL evaluadora
            var sql = @"
                SELECT 
                    p.IdProducto, 
                    p.Codigo, 
                    p.Nombre, 
                    p.Detalle, 
                    p.CantidadActual, 
                    p.StockCritico, 
                    p.Bodega, 
                    p.Pasillo, 
                    p.Estante,
                    (SELECT MAX(r.FechaRecepcion) FROM RECEPCION r 
                     INNER JOIN DETALLE_RECEPCION dr ON r.IdRecepcion = dr.IdRecepcion 
                     WHERE dr.IdProducto = p.IdProducto) AS UltimoIngreso,
                    (SELECT MAX(d.FechaDespacho) FROM DESPACHO d 
                     INNER JOIN DETALLE_DESPACHO dd ON d.IdDespacho = dd.IdDespacho 
                     WHERE dd.IdProducto = p.IdProducto) AS UltimoDespacho,
                    fn_VerificarAlertaStock(p.IdProducto) AS EstadoAlerta
                FROM PRODUCTO p";

            // En EF Core 8, SqlQueryRaw mapea directamente la respuesta SQL al DTO
            var productos = await _context.Database.SqlQueryRaw<ProductoDto>(sql).ToListAsync();
            
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProducto), new { id = producto.IdProducto }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.IdProducto) return BadRequest();
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}