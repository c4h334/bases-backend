using BasesBackend.Domain.Entities;

namespace BasesBackend.Infrastructure.Respositories;

public interface IAuditoriaProductoRepository
{
    Task<IEnumerable<AuditoriaProducto>> GetAllAsync();
    Task<AuditoriaProducto?> GetByIdAsync(int id);
}