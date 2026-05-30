using BasesBackend.Api.Mappers;
using BasesBackend.Api.Models.Requests;
using BasesBackend.Api.Models.Responses;
using BasesBackend.Facade;
using Microsoft.AspNetCore.Mvc;

namespace BasesBackend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DespachoController : ControllerBase
{
    private readonly IDespachoFacade _despachoFacade;

    public DespachoController(IDespachoFacade despachoFacade)
    {
        _despachoFacade = despachoFacade;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DespachoResponse>>> GetAll()
    {
        var despachosDto = await _despachoFacade.GetAllAsync();
        var listaDtos = despachosDto.ToList();
        return Ok(DespachoMapper.ToResponse(listaDtos));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DespachoResponse>> GetById(int id)
    {
        var despachoDto = await _despachoFacade.GetByIdAsync(id);
        if (despachoDto == null) return NotFound();
        return Ok(DespachoMapper.ToResponse(despachoDto));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateDespachoRequest model)
    {
        var dto = DespachoMapper.ToDto(model);
        await _despachoFacade.AddAsync(dto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateDespachoRequest model)
    {
        model.IdDespacho = id;
        var dto = DespachoMapper.ToDto(model);
        await _despachoFacade.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _despachoFacade.DeleteAsync(id);
        return NoContent();
    }
}