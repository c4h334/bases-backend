using BasesBackend.Dto;
using BasesBackend.DomainService;
using BasesBackend.Domain.Entities;

namespace BasesBackend.Facade;

public class DetalleRecepcionFacade : IDetalleRecepcionFacade
{
    private readonly IDetalleRecepcionService _service;

    public DetalleRecepcionFacade(IDetalleRecepcionService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<DetalleRecepcionDto>> GetAllAsync()
    {
        var entities = await _service.GetAllAsync();
        return entities.Select(e => new DetalleRecepcionDto
        {
            IdDetalleRecepcion = e.IdDetalleRecepcion,
            IdRecepcion = e.IdRecepcion,
            IdProducto = e.IdProducto,
            Cantidad = e.Cantidad
        });
    }

    public async Task<DetalleRecepcionDto?> GetByIdAsync(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return null;
        return new DetalleRecepcionDto
        {
            IdDetalleRecepcion = entity.IdDetalleRecepcion,
            IdRecepcion = entity.IdRecepcion,
            IdProducto = entity.IdProducto,
            Cantidad = entity.Cantidad
        };
    }

    public async Task AddAsync(DetalleRecepcionDto dto)
    {
        var entity = new DetalleRecepcion
        {
            IdRecepcion = dto.IdRecepcion,
            IdProducto = dto.IdProducto,
            Cantidad = dto.Cantidad
        };
        await _service.AddAsync(entity);
    }

    public async Task UpdateAsync(DetalleRecepcionDto dto)
    {
        var entity = new DetalleRecepcion
        {
            IdDetalleRecepcion = dto.IdDetalleRecepcion,
            IdRecepcion = dto.IdRecepcion,
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