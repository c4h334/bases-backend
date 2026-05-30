using BasesBackend.Domain.Entities;
using BasesBackend.Infrastructure.Respositories;

namespace BasesBackend.DomainService;

public class DetalleDespachoService : IDetalleDespachoService
{
    private readonly IDetalleDespachoRepository _repository;

    public DetalleDespachoService(IDetalleDespachoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DetalleDespacho>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<DetalleDespacho?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(DetalleDespacho entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(DetalleDespacho entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}