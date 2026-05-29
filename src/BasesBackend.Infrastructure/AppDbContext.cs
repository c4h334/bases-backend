using Microsoft.EntityFrameworkCore;

namespace BasesBackend.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    
}