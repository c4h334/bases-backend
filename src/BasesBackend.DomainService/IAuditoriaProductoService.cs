using BasesBackend.Domain.Entities;

namespace BasesBackend.DomainService;

public interface IAuditoriaProductoService
{
    Task<IEnumerable<AuditoriaProducto>> GetAllAsync();
    Task<AuditoriaProducto?> GetByIdAsync(int id);
}