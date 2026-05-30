using BasesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasesBackend.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Recepcion> Recepciones { get; set; }
    public DbSet<DetalleRecepcion> DetallesRecepcion { get; set; }
    public DbSet<Despacho> Despachos { get; set; }
    public DbSet<CarritoDespacho> CarritosDespacho { get; set; }
    public DbSet<DetalleDespacho> DetallesDespacho { get; set; }
    public DbSet<AuditoriaProducto> AuditoriaProductos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("CLIENTE");
            entity.HasKey(e => e.IdCliente);
            entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.RolCliente).IsRequired();
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("PRODUCTO");
            entity.HasKey(e => e.IdProducto);
            entity.Property(e => e.Codigo).HasMaxLength(20).IsRequired();
            entity.HasIndex(e => e.Codigo).IsUnique();
            entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Detalle).HasMaxLength(255);
            entity.Property(e => e.CantidadActual).HasDefaultValue(0);
            entity.Property(e => e.StockCritico).IsRequired();
            entity.Property(e => e.Bodega).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Pasillo).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Estante).HasMaxLength(50).IsRequired();
        });

        modelBuilder.Entity<Recepcion>(entity =>
        {
            entity.ToTable("RECEPCION");
            entity.HasKey(e => e.IdRecepcion);
            entity.Property(e => e.NumeroLote).HasMaxLength(50).IsRequired();
            entity.Property(e => e.FechaRecepcion).IsRequired();
            entity.Property(e => e.UsuarioAtendio).HasMaxLength(50).IsRequired();
            entity.HasOne<Cliente>().WithMany().HasForeignKey(e => e.IdCliente);
        });

        modelBuilder.Entity<DetalleRecepcion>(entity =>
        {
            entity.ToTable("DETALLE_RECEPCION");
            entity.HasKey(e => e.IdDetalleRecepcion);
            entity.Property(e => e.Cantidad).IsRequired();
            entity.HasOne<Recepcion>().WithMany().HasForeignKey(e => e.IdRecepcion);
            entity.HasOne<Producto>().WithMany().HasForeignKey(e => e.IdProducto);
        });

        modelBuilder.Entity<Despacho>(entity =>
        {
            entity.ToTable("DESPACHO");
            entity.HasKey(e => e.IdDespacho);
            entity.Property(e => e.FechaDespacho).IsRequired();
            entity.Property(e => e.Estado).IsRequired();
            entity.Property(e => e.Operario).HasMaxLength(50).IsRequired();
            entity.HasOne<Cliente>().WithMany().HasForeignKey(e => e.IdCliente);
        });

        modelBuilder.Entity<CarritoDespacho>(entity =>
        {
            entity.ToTable("CARRITO_DESPACHO");
            entity.HasKey(e => e.IdCarrito);
            entity.Property(e => e.Cantidad).IsRequired();
            entity.HasOne<Despacho>().WithMany().HasForeignKey(e => e.IdDespacho);
            entity.HasOne<Producto>().WithMany().HasForeignKey(e => e.IdProducto);
        });

        modelBuilder.Entity<DetalleDespacho>(entity =>
        {
            entity.ToTable("DETALLE_DESPACHO");
            entity.HasKey(e => e.IdDetalle);
            entity.Property(e => e.Cantidad).IsRequired();
            entity.HasOne<Despacho>().WithMany().HasForeignKey(e => e.IdDespacho);
            entity.HasOne<Producto>().WithMany().HasForeignKey(e => e.IdProducto);
        });

        modelBuilder.Entity<AuditoriaProducto>(entity =>
        {
            entity.ToTable("AUDITORIA_PRODUCTO");
            entity.HasKey(e => e.IdAuditoria);
            entity.Property(e => e.FechaMovimiento).IsRequired();
            entity.Property(e => e.CantidadAnterior).IsRequired();
            entity.Property(e => e.CantidadNueva).IsRequired();
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50).IsRequired();
            entity.HasOne<Producto>().WithMany().HasForeignKey(e => e.IdProducto);
        });
    }
}