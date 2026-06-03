using Dominio.Interfaces.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FaOuHaterApi.Controllers.Core;

public abstract class RestController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    public IMediator Mediator => _mediator;

    protected IActionResult ActionResult(IHttpResult httpResult) => StatusCode(httpResult.GetStatusCode(), httpResult);
}
