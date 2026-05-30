using BasesBackend.Domain.Entities;

namespace BasesBackend.Infrastructure.Respositories;

public interface IDespachoRepository
{
    Task<IEnumerable<Despacho>> GetAllAsync();
    Task<Despacho?> GetByIdAsync(int id);
    Task AddAsync(Despacho entity);
    Task UpdateAsync(Despacho entity);
    Task DeleteAsync(int id);
}