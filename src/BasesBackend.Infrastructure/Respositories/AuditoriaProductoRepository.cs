using BasesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasesBackend.Infrastructure.Respositories;

public class AuditoriaProductoRepository : IAuditoriaProductoRepository
{
    private readonly AppDbContext _context;

    public AuditoriaProductoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AuditoriaProducto>> GetAllAsync()
    {
        return await _context.AuditoriaProductos.AsNoTracking().ToListAsync();
    }

    public async Task<AuditoriaProducto?> GetByIdAsync(int id)
    {
        return await _context.AuditoriaProductos.AsNoTracking().FirstOrDefaultAsync(x => x.IdAuditoria == id);
    }
}