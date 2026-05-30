using Microsoft.EntityFrameworkCore;
using BasesBackend.Infrastructure;
using BasesBackend.Infrastructure.Respositories;
using BasesBackend.DomainService;
using BasesBackend.Facade;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOriginsPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigins!)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// --- INYECCIÓN DE DEPENDENCIAS (DI) ---

// 1. Repositories (Infrastructure)
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IRecepcionRepository, RecepcionRepository>();
builder.Services.AddScoped<IDetalleRecepcionRepository, DetalleRecepcionRepository>();
builder.Services.AddScoped<IDespachoRepository, DespachoRepository>();
builder.Services.AddScoped<ICarritoDespachoRepository, CarritoDespachoRepository>();
builder.Services.AddScoped<IDetalleDespachoRepository, DetalleDespachoRepository>();
builder.Services.AddScoped<IAuditoriaProductoRepository, AuditoriaProductoRepository>();

// 2. Services (DomainService)
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IRecepcionService, RecepcionService>();
builder.Services.AddScoped<IDetalleRecepcionService, DetalleRecepcionService>();
builder.Services.AddScoped<IDespachoService, DespachoService>();
builder.Services.AddScoped<ICarritoDespachoService, CarritoDespachoService>();
builder.Services.AddScoped<IDetalleDespachoService, DetalleDespachoService>();
builder.Services.AddScoped<IAuditoriaProductoService, AuditoriaProductoService>();

// 3. Facades (Facade)
builder.Services.AddScoped<IClienteFacade, ClienteFacade>();
builder.Services.AddScoped<IProductoFacade, ProductoFacade>();
builder.Services.AddScoped<IRecepcionFacade, RecepcionFacade>();
builder.Services.AddScoped<IDetalleRecepcionFacade, DetalleRecepcionFacade>();
builder.Services.AddScoped<IDespachoFacade, DespachoFacade>();
builder.Services.AddScoped<ICarritoDespachoFacade, CarritoDespachoFacade>();
builder.Services.AddScoped<IDetalleDespachoFacade, DetalleDespachoFacade>();
builder.Services.AddScoped<IAuditoriaProductoFacade, AuditoriaProductoFacade>();

// --------------------------------------

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowedOriginsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();