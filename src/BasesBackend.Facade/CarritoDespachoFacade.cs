using BasesBackend.Dto;
using BasesBackend.DomainService;
using BasesBackend.Domain.Entities;

namespace BasesBackend.Facade;

public class CarritoDespachoFacade : ICarritoDespachoFacade
{
    private readonly ICarritoDespachoService _service;

    public CarritoDespachoFacade(ICarritoDespachoService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<CarritoDespachoDto>> GetAllAsync()
    {
        var entities = await _service.GetAllAsync();
        return entities.Select(e => new CarritoDespachoDto
        {
            IdCarrito = e.IdCarrito,
            IdDespacho = e.IdDespacho,
            IdProducto = e.IdProducto,
            Cantidad = e.Cantidad
        });
    }

    public async Task<CarritoDespachoDto?> GetByIdAsync(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return null;
        return new CarritoDespachoDto
        {
            IdCarrito = entity.IdCarrito,
            IdDespacho = entity.IdDespacho,
            IdProducto = entity.IdProducto,
            Cantidad = entity.Cantidad
        };
    }

    public async Task AddAsync(CarritoDespachoDto dto)
    {
        var entity = new CarritoDespacho
        {
            IdDespacho = dto.IdDespacho,
            IdProducto = dto.IdProducto,
            Cantidad = dto.Cantidad
        };
        await _service.AddAsync(entity);
    }

    public async Task UpdateAsync(CarritoDespachoDto dto)
    {
        var entity = new CarritoDespacho
        {
            IdCarrito = dto.IdCarrito,
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