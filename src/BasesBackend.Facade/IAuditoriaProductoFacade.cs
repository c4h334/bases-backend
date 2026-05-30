using BasesBackend.Dto;

namespace BasesBackend.Facade;

public interface IAuditoriaProductoFacade
{
    Task<IEnumerable<AuditoriaProductoDto>> GetAllAsync();
    Task<AuditoriaProductoDto?> GetByIdAsync(int id);
}