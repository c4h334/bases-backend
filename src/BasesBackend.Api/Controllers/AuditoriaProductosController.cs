using Microsoft.AspNetCore.Mvc;
using BasesBackend.Facade;
using BasesBackend.Dto;

namespace BasesBackend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuditoriaProductosController : ControllerBase
{
    private readonly IAuditoriaProductoFacade _facade;

    public AuditoriaProductosController(IAuditoriaProductoFacade facade)
    {
        _facade = facade;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuditoriaProductoDto>>> GetAll()
    {
        var result = await _facade.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuditoriaProductoDto>> GetById(int id)
    {
        var result = await _facade.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }
}