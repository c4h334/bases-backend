using BasesBackend.Dto;
using BasesBackend.DomainService;
using BasesBackend.Domain.Entities;

namespace BasesBackend.Facade;

public class AuditoriaProductoFacade : IAuditoriaProductoFacade
{
    private readonly IAuditoriaProductoService _service;

    public AuditoriaProductoFacade(IAuditoriaProductoService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<AuditoriaProductoDto>> GetAllAsync()
    {
        var entities = await _service.GetAllAsync();
        return entities.Select(e => new AuditoriaProductoDto
        {
            IdAuditoria = e.IdAuditoria,
            IdProducto = e.IdProducto,
            FechaMovimiento = e.FechaMovimiento,
            CantidadAnterior = e.CantidadAnterior,
            CantidadNueva = e.CantidadNueva,
            UsuarioModificacion = e.UsuarioModificacion
        });
    }

    public async Task<AuditoriaProductoDto?> GetByIdAsync(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return null;

        return new AuditoriaProductoDto
        {
            IdAuditoria = entity.IdAuditoria,
            IdProducto = entity.IdProducto,
            FechaMovimiento = entity.FechaMovimiento,
            CantidadAnterior = entity.CantidadAnterior,
            CantidadNueva = entity.CantidadNueva,
            UsuarioModificacion = entity.UsuarioModificacion
        };
    }
}