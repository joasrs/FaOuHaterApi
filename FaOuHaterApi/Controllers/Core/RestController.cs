using Dominio.Enum;
using Dominio.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace FaOuHaterApi.Controllers.Core
{
    public abstract class RestController : ControllerBase
    {
        protected IActionResult ActionResult(IHttpResult httpResult)
        {
            var statusCode = httpResult.GetStatusCode();
            return statusCode switch
            {
                EnumHttpStatusCode.Created or
                EnumHttpStatusCode.Unauthorized or
                EnumHttpStatusCode.InternalServerError => StatusCode((int)statusCode),
                EnumHttpStatusCode.Ok or
                EnumHttpStatusCode.NotFound or
                EnumHttpStatusCode.BadRequest or
                EnumHttpStatusCode.InvalidInput => StatusCode((int)statusCode, httpResult),
                _ => StatusCode(StatusCodes.Status500InternalServerError, "Código de status desconhecido"),
            };
        }
    }
}
