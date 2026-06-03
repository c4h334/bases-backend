using Microsoft.EntityFrameworkCore;
using BasesBackend.Domain.Entities;

namespace BasesBackend.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Recepcion> Recepciones { get; set; }
        public DbSet<DetalleRecepcion> DetallesRecepcion { get; set; }
        public DbSet<Despacho> Despachos { get; set; }
        public DbSet<DetalleDespacho> DetallesDespacho { get; set; }
        public DbSet<CarritoDespacho> CarritosDespacho { get; set; }
        public DbSet<AuditoriaProducto> AuditoriaProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Despacho>()
                .HasOne(d => d.Cliente)
                .WithMany()
                .HasForeignKey(d => d.IdCliente)
                .IsRequired();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
