using BasesBackend.Api.Models.Requests;
using BasesBackend.Api.Models.Responses;
using BasesBackend.Dto;

namespace BasesBackend.Api.Mappers;

public class RecepcionMapper
{
    public static RecepcionDto ToDto(CreateRecepcionRequest model)
    {
        return new RecepcionDto
        {
            IdCliente = model.IdCliente,
            NumeroLote = model.NumeroLote,
            FechaRecepcion = model.FechaRecepcion,
            UsuarioAtendio = model.UsuarioAtendio
        };
    }

    public static RecepcionDto ToDto(UpdateRecepcionRequest model)
    {
        return new RecepcionDto
        {
            IdRecepcion = model.IdRecepcion,
            IdCliente = model.IdCliente,
            NumeroLote = model.NumeroLote,
            FechaRecepcion = model.FechaRecepcion,
            UsuarioAtendio = model.UsuarioAtendio
        };
    }

    public static List<RecepcionResponse> ToResponse(List<RecepcionDto> recepciones)
    {
        return recepciones.Select(r => ToResponse(r)).ToList();
    }

    public static RecepcionResponse ToResponse(RecepcionDto recepcion)
    {
        return new RecepcionResponse
        {
            IdRecepcion = recepcion.IdRecepcion,
            IdCliente = recepcion.IdCliente,
            NumeroLote = recepcion.NumeroLote,
            FechaRecepcion = recepcion.FechaRecepcion,
            UsuarioAtendio = recepcion.UsuarioAtendio
        };
    }
}