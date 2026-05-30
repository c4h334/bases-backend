using BasesBackend.Dto;
using BasesBackend.DomainService;
using BasesBackend.Domain.Entities;

namespace BasesBackend.Facade;

public class DetalleDespachoFacade : IDetalleDespachoFacade
{
    private readonly IDetalleDespachoService _service;

    public DetalleDespachoFacade(IDetalleDespachoService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<DetalleDespachoDto>> GetAllAsync()
    {
        var entities = await _service.GetAllAsync();
        return entities.Select(e => new DetalleDespachoDto
        {
            IdDetalle = e.IdDetalle,
            IdDespacho = e.IdDespacho,
            IdProducto = e.IdProducto,
            Cantidad = e.Cantidad
        });
    }

    public async Task<DetalleDespachoDto?> GetByIdAsync(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return null;
        return new DetalleDespachoDto
        {
            IdDetalle = entity.IdDetalle,
            IdDespacho = entity.IdDespacho,
            IdProducto = entity.IdProducto,
            Cantidad = entity.Cantidad
        };
    }

    public async Task AddAsync(DetalleDespachoDto dto)
    {
        var entity = new DetalleDespacho
        {
            IdDespacho = dto.IdDespacho,
            IdProducto = dto.IdProducto,
            Cantidad = dto.Cantidad
        };
        await _service.AddAsync(entity);
    }

    public async Task UpdateAsync(DetalleDespachoDto dto)
    {
        var entity = new DetalleDespacho
        {
            IdDetalle = dto.IdDetalle,
            IdDespacho = dto.IdDespacho,
            IdProducto = dto.IdProducto,
            Cantidad = dto.Cantidad
        };
        await _service.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _service.DeleteAsync(id);
    }
}