using BasesBackend.Domain.Entities;

namespace BasesBackend.Infrastructure.Respositories;

public interface ICarritoDespachoRepository
{
    Task<IEnumerable<CarritoDespacho>> GetAllAsync();
    Task<CarritoDespacho?> GetByIdAsync(int id);
    Task AddAsync(CarritoDespacho entity);
    Task UpdateAsync(CarritoDespacho entity);
    Task DeleteAsync(int id);
}