using BasesBackend.Domain.Entities;

namespace BasesBackend.DomainService;

public interface IRecepcionService
{
    Task<IEnumerable<Recepcion>> GetAllAsync();
    Task<Recepcion?> GetByIdAsync(int id);
    Task AddAsync(Recepcion entity);
    Task UpdateAsync(Recepcion entity);
    Task DeleteAsync(int id);
}