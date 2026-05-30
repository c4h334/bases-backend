using BasesBackend.Domain.Entities;

namespace BasesBackend.Infrastructure.Respositories;

public interface IRecepcionRepository
{
    Task<IEnumerable<Recepcion>> GetAllAsync();
    Task<Recepcion?> GetByIdAsync(int id);
    Task AddAsync(Recepcion entity);
    Task UpdateAsync(Recepcion entity);
    Task DeleteAsync(int id);
}