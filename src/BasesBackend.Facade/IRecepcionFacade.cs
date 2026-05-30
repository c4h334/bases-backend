using BasesBackend.Dto;

namespace BasesBackend.Facade;

public interface IRecepcionFacade
{
    Task<IEnumerable<RecepcionDto>> GetAllAsync();
    Task<RecepcionDto?> GetByIdAsync(int id);
    Task AddAsync(RecepcionDto dto);
    Task UpdateAsync(RecepcionDto dto);
    Task DeleteAsync(int id);
}