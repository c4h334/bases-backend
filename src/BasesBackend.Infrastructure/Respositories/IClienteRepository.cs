using BasesBackend.Domain.Entities;

namespace BasesBackend.Infrastructure.Respositories;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(int id);
    Task AddAsync(Cliente entity);
    Task UpdateAsync(Cliente entity);
    Task DeleteAsync(int id);
}