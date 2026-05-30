using BasesBackend.Domain.Entities;
using BasesBackend.Infrastructure.Respositories;

namespace BasesBackend.DomainService;

public class AuditoriaProductoService : IAuditoriaProductoService
{
    private readonly IAuditoriaProductoRepository _repository;

    public AuditoriaProductoService(IAuditoriaProductoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AuditoriaProducto>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<AuditoriaProducto?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
}