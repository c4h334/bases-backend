using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace BasesBackend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest(new { message = "Por favor, ingrese su usuario y contraseña." });
        }

        // Configuramos la cadena forzando el protocolo nativo de comunicación por tubería/socket local
        var builder = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Port = 3307,
            Database = "ProyectoBD2",
            UserID = request.Username.Trim(),
            Password = request.Password,
            PersistSecurityInfo = true
        };

        try
        {
            using var connection = new MySqlConnection(builder.ConnectionString);
            await connection.OpenAsync();
            
            return Ok(new { 
                username = request.Username.Trim(), 
                message = "Autenticación de base de datos exitosa." 
            });
        }
        catch (MySqlException ex)
        {
            return Unauthorized(new { message = $"Acceso denegado por MySQL: {ex.Message}" });
        }
    }
}

public class LoginRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}