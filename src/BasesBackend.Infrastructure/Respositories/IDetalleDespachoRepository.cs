using BasesBackend.Domain.Entities;

namespace BasesBackend.Infrastructure.Respositories;

public interface IDetalleDespachoRepository
{
    Task<IEnumerable<DetalleDespacho>> GetAllAsync();
    Task<DetalleDespacho?> GetByIdAsync(int id);
    Task AddAsync(DetalleDespacho entity);
    Task UpdateAsync(DetalleDespacho entity);
    Task DeleteAsync(int id);
}