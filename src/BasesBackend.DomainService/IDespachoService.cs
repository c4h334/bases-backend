using BasesBackend.Domain.Entities;

namespace BasesBackend.DomainService;

public interface IDespachoService
{
    Task<IEnumerable<Despacho>> GetAllAsync();
    Task<Despacho?> GetByIdAsync(int id);
    Task AddAsync(Despacho entity);
    Task UpdateAsync(Despacho entity);
    Task DeleteAsync(int id);
}