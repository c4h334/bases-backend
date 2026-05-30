using BasesBackend.Domain.Entities;
using BasesBackend.Infrastructure.Respositories;

namespace BasesBackend.DomainService;

public class DespachoService : IDespachoService
{
    private readonly IDespachoRepository _repository;

    public DespachoService(IDespachoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Despacho>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Despacho?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Despacho entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(Despacho entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}