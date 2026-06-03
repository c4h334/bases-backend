using BasesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasesBackend.Infrastructure.Respositories;

public class CarritoDespachoRepository : ICarritoDespachoRepository
{
    private readonly AppDbContext _context;
    public CarritoDespachoRepository(AppDbContext context) { _context = context; }

    public async Task<IEnumerable<CarritoDespacho>> GetAllAsync() => await _context.CarritosDespacho.ToListAsync();
    
    public async Task<CarritoDespacho?> GetByIdAsync(int id) => await _context.CarritosDespacho.FindAsync(id);
    
    public async Task AddAsync(CarritoDespacho entity) {
        await _context.CarritosDespacho.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    // Método faltante que exige la interfaz
    public async Task UpdateAsync(CarritoDespacho entity) {
        _context.CarritosDespacho.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) {
        var x = await _context.CarritosDespacho.FindAsync(id);
        if (x != null) {
            _context.CarritosDespacho.Remove(x);
            await _context.SaveChangesAsync();
        }
    }
}
