using BasesBackend.Dto;
using BasesBackend.DomainService;
using BasesBackend.Domain.Entities;

namespace BasesBackend.Facade;

public class DespachoFacade : IDespachoFacade
{
    private readonly IDespachoService _service;

    public DespachoFacade(IDespachoService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<DespachoDto>> GetAllAsync()
    {
        var entities = await _service.GetAllAsync();
        return entities.Select(e => new DespachoDto
        {
            IdDespacho = e.IdDespacho,
            IdCliente = e.IdCliente,
            FechaDespacho = e.FechaDespacho,
            Estado = e.Estado,
            Operario = e.Operario
        });
    }

    public async Task<DespachoDto?> GetByIdAsync(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return null;
        return new DespachoDto
        {
            IdDespacho = entity.IdDespacho,
            IdCliente = entity.IdCliente,
            FechaDespacho = entity.FechaDespacho,
            Estado = entity.Estado,
            Operario = entity.Operario
        };
    }

    public async Task AddAsync(DespachoDto dto)
    {
        var entity = new Despacho
        {
            IdCliente = dto.IdCliente,
            FechaDespacho = dto.FechaDespacho,
            Estado = dto.Estado,
            Operario = dto.Operario
        };
        await _service.AddAsync(entity);
    }

    public async Task UpdateAsync(DespachoDto dto)
    {
        var entity = new Despacho
        {
            IdDespacho = dto.IdDespacho,
            IdCliente = dto.IdCliente,
            FechaDespacho = dto.FechaDespacho,
            Estado = dto.Estado,
            Operario = dto.Operario
        };
        await _service.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _service.DeleteAsync(id);
    }
}