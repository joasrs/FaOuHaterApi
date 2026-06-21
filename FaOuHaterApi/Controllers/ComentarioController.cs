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
public class ComentarioController(IMediator mediator) : RestController
{
    [HttpGet]
    public async Task<IActionResult> ObterComentarios([FromQuery] ObterComentariosRequest request)
    {
        return ActionResult(await mediator.Send(request));
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarComentario([FromBody] AdicionarComentarioRequest request)
    {
        return ActionResult(await mediator.Send(request));
    }

    [HttpDelete("{idComentario}")]
    public async Task<IActionResult> DeletarComentario([FromRoute] DeletarComentarioRequest request)
    {
        return ActionResult(await mediator.Send(request));
    }
}
