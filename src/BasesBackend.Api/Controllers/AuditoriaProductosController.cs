using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasesBackend.Infrastructure;
using BasesBackend.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BasesBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuditoriaProductosController(AppDbContext context)
        {
            _context = context;
        }

        // 1. RESULTADO DE MOVIMIENTOS: Consulta optimizada con JOINs para reportes de ingresos y salidas
        [HttpGet("movimientos")]
        public async Task<IActionResult> GetMovimientos([FromQuery] string codigo, [FromQuery] System.DateTime? fechaInicio, [FromQuery] System.DateTime? fechaFin)
        {
            try {
                if (string.IsNullOrEmpty(codigo)) {
                    return BadRequest(new { message = "El código del producto es obligatorio." });
                }

                // Configuración de fechas por defecto según la rúbrica (rango de un mes)
                var fin = fechaFin ?? System.DateTime.Now;
                var inicio = fechaInicio ?? System.DateTime.Now.AddMonths(-1);

                var producto = await _context.Set<Producto>().FirstOrDefaultAsync(p => p.Codigo == codigo);
                if (producto == null) {
                    return NotFound(new { message = "Producto no encontrado." });
                }

                // JOIN optimizado para capturar las Recepciones (Ingresos)
                var ingresos = await (from dr in _context.Set<DetalleRecepcion>()
                                      join r in _context.Set<Recepcion>() on dr.IdRecepcion equals r.IdRecepcion
                                      join c in _context.Set<Cliente>() on r.IdCliente equals c.IdCliente
                                      where dr.IdProducto == producto.IdProducto && r.FechaRecepcion >= inicio && r.FechaRecepcion <= fin
                                      select new {
                                          Fecha = r.FechaRecepcion,
                                          Tipo = "Recepción",
                                          Cliente = c.Nombre,
                                          Cantidad = dr.Cantidad,
                                          Usuario = r.UsuarioAtendio
                                      }).ToListAsync();

                // JOIN optimizado para capturar los Despachos (Salidas)
                var salidas = await (from dd in _context.Set<DetalleDespacho>()
                                     join d in _context.Set<Despacho>() on dd.IdDespacho equals d.IdDespacho
                                     join c in _context.Set<Cliente>() on d.IdCliente equals c.IdCliente
                                     where dd.IdProducto == producto.IdProducto && d.FechaDespacho >= inicio && d.FechaDespacho <= fin
                                     select new {
                                         Fecha = d.FechaDespacho,
                                         Tipo = "Despacho",
                                         Cliente = c.Nombre,
                                         Cantidad = dd.Cantidad,
                                         Usuario = d.Operario
                                     }).ToListAsync();

                // Unificación de flujos cronológicos en orden decreciente
                var resultadoCompleto = ingresos.Concat(salidas)
                                                 .OrderByDescending(m => m.Fecha)
                                                 .ToList();

                return Ok(resultadoCompleto);
            } catch (System.Exception ex) {
                return BadRequest(new { message = ex.Message });
            }
        }

        // 2. RESULTADO DE AUDITORÍA: Consulta sobre el log de bitácora alimentado por el Trigger
        [HttpGet("log-auditoria")]
        public async Task<IActionResult> GetAuditoriaLog([FromQuery] string codigo, [FromQuery] System.DateTime? fechaInicio, [FromQuery] System.DateTime? fechaFin)
        {
            try {
                if (string.IsNullOrEmpty(codigo)) {
                    return BadRequest(new { message = "El código del producto es obligatorio." });
                }

                var fin = fechaFin ?? System.DateTime.Now;
                var inicio = fechaInicio ?? System.DateTime.Now.AddMonths(-1);

                var producto = await _context.Set<Producto>().FirstOrDefaultAsync(p => p.Codigo == codigo);
                if (producto == null) {
                    return NotFound(new { message = "Producto no encontrado." });
                }

                // Consulta optimizada sobre la bitácora del trigger ordenada de forma decreciente
                var logs = await _context.Set<AuditoriaProducto>()
                    .Where(a => a.IdProducto == producto.IdProducto && a.FechaMovimiento >= inicio && a.FechaMovimiento <= fin)
                    .OrderByDescending(a => a.FechaMovimiento)
                    .Select(a => new {
                        Fecha = a.FechaMovimiento,
                        CantidadAnterior = a.CantidadAnterior,
                        CantidadNueva = a.CantidadNueva,
                        Efecto = a.CantidadNueva > a.CantidadAnterior ? "Incremento" : "Reducción",
                        Usuario = a.UsuarioModificacion
                    })
                    .ToListAsync();

                return Ok(logs);
            } catch (System.Exception ex) {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
