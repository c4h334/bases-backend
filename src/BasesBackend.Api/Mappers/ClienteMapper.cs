using BasesBackend.Api.Models.Requests;
using BasesBackend.Api.Models.Responses;
using BasesBackend.Dto;

namespace BasesBackend.Api.Mappers;

public class ClienteMapper
{
    public static ClienteDto ToDto(CreateClienteRequest model)
    {
        return new ClienteDto
        {
            Nombre = model.Nombre,
            Telefono = model.Telefono,
            Correo = model.Correo,
            Direccion = model.Direccion,
            RolCliente = model.RolCliente
        };
    }

    public static ClienteDto ToDto(UpdateClienteRequest model)
    {
        return new ClienteDto
        {
            IdCliente = model.IdCliente,
            Nombre = model.Nombre,
            Telefono = model.Telefono,
            Correo = model.Correo,
            Direccion = model.Direccion,
            RolCliente = model.RolCliente
        };
    }

    public static List<ClienteResponse> ToResponse(List<ClienteDto> clientes)
    {
        return clientes.Select(c => ToResponse(c)).ToList();
    }

    public static ClienteResponse ToResponse(ClienteDto cliente)
    {
        return new ClienteResponse
        {
            IdCliente = cliente.IdCliente,
            Nombre = cliente.Nombre,
            Telefono = cliente.Telefono,
            Correo = cliente.Correo,
            Direccion = cliente.Direccion,
            RolCliente = cliente.RolCliente
        };
    }
}