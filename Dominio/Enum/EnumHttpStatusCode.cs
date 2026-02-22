using Microsoft.AspNetCore.Http;

namespace Dominio.Enum
{
    public enum EnumHttpStatusCode : int
    {
        Ok = StatusCodes.Status200OK,
        Created = StatusCodes.Status201Created,
        NotFound = StatusCodes.Status404NotFound,
        BadRequest = StatusCodes.Status400BadRequest,
        Unauthorized = StatusCodes.Status401Unauthorized,
        InvalidInput = StatusCodes.Status422UnprocessableEntity,
        InternalServerError = StatusCodes.Status500InternalServerError,
    }
}
