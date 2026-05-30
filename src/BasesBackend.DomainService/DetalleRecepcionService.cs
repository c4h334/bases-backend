using BasesBackend.Domain.Entities;
using BasesBackend.Infrastructure.Respositories;

namespace BasesBackend.DomainService;

public class DetalleRecepcionService : IDetalleRecepcionService
{
    private readonly IDetalleRecepcionRepository _repository;

    public DetalleRecepcionService(IDetalleRecepcionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DetalleRecepcion>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<DetalleRecepcion?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(DetalleRecepcion entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(DetalleRecepcion entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}