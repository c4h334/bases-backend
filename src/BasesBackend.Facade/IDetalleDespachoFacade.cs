using BasesBackend.Dto;

namespace BasesBackend.Facade;

public interface IDetalleDespachoFacade
{
    Task<IEnumerable<DetalleDespachoDto>> GetAllAsync();
    Task<DetalleDespachoDto?> GetByIdAsync(int id);
    Task AddAsync(DetalleDespachoDto dto);
    Task UpdateAsync(DetalleDespachoDto dto);
    Task DeleteAsync(int id);
}