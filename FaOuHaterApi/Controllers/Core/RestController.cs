using Dominio.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace FaOuHaterApi.Controllers.Core;

public abstract class RestController : ControllerBase
{
    protected IActionResult ActionResult(IHttpResult httpResult) => StatusCode(httpResult.GetStatusCode(), httpResult);
}
