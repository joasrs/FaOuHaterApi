using Aplicacao.Handlers.Auth;
using Aplicacao.Handlers.Auth.Login;
using FaOuHaterApi.Controllers.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FaOuHaterApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutenticacaoController : RestController
{
    public AutenticacaoController(IMediator mediator) : base(mediator)
    {
    }

    // POST api/<AutenticacaoController>
    [HttpPost]
    public async Task<IActionResult> Cadastro([FromBody] CadastrarUsuarioRequest request)
    {
        return ActionResult(await Mediator.Send(request));
    }

    // POST api/<AutenticacaoController>
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        return ActionResult(await Mediator.Send(request));
    }
}
