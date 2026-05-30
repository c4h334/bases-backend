using BasesBackend.Domain.Entities;
using BasesBackend.Infrastructure.Respositories;

namespace BasesBackend.DomainService;

public class CarritoDespachoService : ICarritoDespachoService
{
    private readonly ICarritoDespachoRepository _repository;

    public CarritoDespachoService(ICarritoDespachoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CarritoDespacho>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<CarritoDespacho?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(CarritoDespacho entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(CarritoDespacho entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}