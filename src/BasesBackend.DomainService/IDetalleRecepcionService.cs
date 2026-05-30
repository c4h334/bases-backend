using BasesBackend.Domain.Entities;

namespace BasesBackend.DomainService;

public interface IDetalleRecepcionService
{
    Task<IEnumerable<DetalleRecepcion>> GetAllAsync();
    Task<DetalleRecepcion?> GetByIdAsync(int id);
    Task AddAsync(DetalleRecepcion entity);
    Task UpdateAsync(DetalleRecepcion entity);
    Task DeleteAsync(int id);
}