using BasesBackend.Domain.Entities;

namespace BasesBackend.DomainService;

public interface IDetalleDespachoService
{
    Task<IEnumerable<DetalleDespacho>> GetAllAsync();
    Task<DetalleDespacho?> GetByIdAsync(int id);
    Task AddAsync(DetalleDespacho entity);
    Task UpdateAsync(DetalleDespacho entity);
    Task DeleteAsync(int id);
}