using BasesBackend.Domain.Entities;
using BasesBackend.Infrastructure.Respositories;

namespace BasesBackend.DomainService;

public class RecepcionService : IRecepcionService
{
    private readonly IRecepcionRepository _repository;

    public RecepcionService(IRecepcionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Recepcion>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Recepcion?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Recepcion entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(Recepcion entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}