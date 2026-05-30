using BasesBackend.Domain.Entities;

namespace BasesBackend.DomainService;

public interface IProductoService
{
    Task<IEnumerable<Producto>> GetAllAsync();
    Task<Producto?> GetByIdAsync(int id);
    Task AddAsync(Producto entity);
    Task UpdateAsync(Producto entity);
    Task DeleteAsync(int id);
}