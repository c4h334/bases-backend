using BasesBackend.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasesBackend.Infrastructure.Respositories;

public interface IProductoRepository
{
    Task<IEnumerable<Producto>> GetAllAsync();
    Task<Producto?> GetByIdAsync(int id);
    Task AddAsync(Producto entity);
    Task UpdateAsync(Producto entity);
    Task DeleteAsync(int id);
    
    // Método para invocar la función de la base de datos
    Task<string> VerificarAlertaStockAsync(int idProducto);
}
