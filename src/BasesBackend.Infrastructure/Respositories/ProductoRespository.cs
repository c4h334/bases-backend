using BasesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasesBackend.Infrastructure.Respositories;

public class ProductoRepository : IProductoRepository
{
    private readonly AppDbContext _context;

    public ProductoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos.AsNoTracking().ToListAsync();
    }

    public async Task<Producto?> GetByIdAsync(int id)
    {
        return await _context.Productos.FirstOrDefaultAsync(x => x.IdProducto == id);
    }

    public async Task AddAsync(Producto entity)
    {
        await _context.Productos.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Producto entity)
    {
        _context.Productos.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Productos.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}