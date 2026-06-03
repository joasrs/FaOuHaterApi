using Aplicacao.Handlers.Comentario.AdicionarComentario;
using Aplicacao.Handlers.Comentario.DeletarComentario;
using Aplicacao.Handlers.Comentario.ObterComentarios;
using FaOuHaterApi.Controllers.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FaOuHaterApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ComentarioController : RestController
{
    public ComentarioController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> ObterComentarios([FromQuery] ObterComentariosRequest request)
    {
        return ActionResult(await Mediator.Send(request));
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarComentario([FromBody] AdicionarComentarioRequest request)
    {
        return ActionResult(await Mediator.Send(request));
    }

    [HttpDelete("{idComentario}")]
    public async Task<IActionResult> DeleterComentario([FromRoute] DeletarComentarioRequest request)
    {
        return ActionResult(await Mediator.Send(request));
    }
}
