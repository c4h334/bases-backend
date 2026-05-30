using BasesBackend.Domain.Entities;

namespace BasesBackend.DomainService;

public interface IClienteService
{
    Task<IEnumerable<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(int id);
    Task AddAsync(Cliente entity);
    Task UpdateAsync(Cliente entity);
    Task DeleteAsync(int id);
}