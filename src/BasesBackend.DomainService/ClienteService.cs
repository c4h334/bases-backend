using BasesBackend.Domain.Entities;
using BasesBackend.Infrastructure.Respositories;

namespace BasesBackend.DomainService;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Cliente entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(Cliente entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}