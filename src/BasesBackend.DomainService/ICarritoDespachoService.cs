using BasesBackend.Domain.Entities;

namespace BasesBackend.DomainService;

public interface ICarritoDespachoService
{
    Task<IEnumerable<CarritoDespacho>> GetAllAsync();
    Task<CarritoDespacho?> GetByIdAsync(int id);
    Task AddAsync(CarritoDespacho entity);
    Task UpdateAsync(CarritoDespacho entity);
    Task DeleteAsync(int id);
}