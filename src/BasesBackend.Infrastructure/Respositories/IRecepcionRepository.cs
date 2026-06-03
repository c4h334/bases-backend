using BasesBackend.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasesBackend.Infrastructure.Respositories;

public interface IRecepcionRepository
{
    Task<IEnumerable<Recepcion>> GetAllAsync();
    Task<Recepcion?> GetByIdAsync(int id);
    Task AddAsync(Recepcion entity);
    Task UpdateAsync(Recepcion entity);
    Task DeleteAsync(int id);
    
    // Nuevo método para llamar al procedure de recepción
    Task<string> RegistrarRecepcionAsync(string numeroLote, string usuarioAtendio, int idCliente, int idProducto, int cantidad);
}
