using BasesBackend.Dto;
using BasesBackend.DomainService;
using BasesBackend.Domain.Entities;

namespace BasesBackend.Facade;

public class RecepcionFacade : IRecepcionFacade
{
    private readonly IRecepcionService _service;

    public RecepcionFacade(IRecepcionService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<RecepcionDto>> GetAllAsync()
    {
        var entities = await _service.GetAllAsync();
        return entities.Select(e => new RecepcionDto
        {
            IdRecepcion = e.IdRecepcion,
            IdCliente = e.IdCliente,
            NumeroLote = e.NumeroLote,
            FechaRecepcion = e.FechaRecepcion,
            UsuarioAtendio = e.UsuarioAtendio
        });
    }

    public async Task<RecepcionDto?> GetByIdAsync(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return null;
        return new RecepcionDto
        {
            IdRecepcion = entity.IdRecepcion,
            IdCliente = entity.IdCliente,
            NumeroLote = entity.NumeroLote,
            FechaRecepcion = entity.FechaRecepcion,
            UsuarioAtendio = entity.UsuarioAtendio
        };
    }

    public async Task AddAsync(RecepcionDto dto)
    {
        var entity = new Recepcion
        {
            IdCliente = dto.IdCliente,
            NumeroLote = dto.NumeroLote,
            FechaRecepcion = dto.FechaRecepcion,
            UsuarioAtendio = dto.UsuarioAtendio
        };
        await _service.AddAsync(entity);
    }

    public async Task UpdateAsync(RecepcionDto dto)
    {
        var entity = new Recepcion
        {
            IdRecepcion = dto.IdRecepcion,
            IdCliente = dto.IdCliente,
            NumeroLote = dto.NumeroLote,
            FechaRecepcion = dto.FechaRecepcion,
            UsuarioAtendio = dto.UsuarioAtendio
        };
        await _service.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _service.DeleteAsync(id);
    }
}