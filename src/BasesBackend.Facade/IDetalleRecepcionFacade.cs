using BasesBackend.Dto;

namespace BasesBackend.Facade;

public interface IDetalleRecepcionFacade
{
    Task<IEnumerable<DetalleRecepcionDto>> GetAllAsync();
    Task<DetalleRecepcionDto?> GetByIdAsync(int id);
    Task AddAsync(DetalleRecepcionDto dto);
    Task UpdateAsync(DetalleRecepcionDto dto);
    Task DeleteAsync(int id);
}