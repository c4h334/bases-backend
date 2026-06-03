using BasesBackend.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasesBackend.Infrastructure.Respositories;

public interface IDespachoRepository
{
    Task<IEnumerable<Despacho>> GetAllAsync();
    Task<Despacho?> GetByIdAsync(int id);
    Task AddAsync(Despacho entity);
    Task UpdateAsync(Despacho entity);
    Task DeleteAsync(int id);
    
    // Nuevo método para llamar al procedure de despacho
    Task<string> ProcesarDespachoAsync(int idDespacho, int idCliente);
}
