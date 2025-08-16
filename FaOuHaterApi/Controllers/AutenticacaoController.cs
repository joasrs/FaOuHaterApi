using Aplicacao.Handlers.Auth;
using Aplicacao.Handlers.Auth.CadastrarUsuario;
using Aplicacao.Handlers.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FaOuHaterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutenticacaoController(IMediator mediator) 
        { 
            _mediator = mediator;
        }

        // POST api/<AutenticacaoController>
        [HttpPost]
        public ActionResult<AuthResponse> Cadastro([FromBody] CadastrarUsuarioRequest request)
        {
            return _mediator.Send(request).Result;
        }

        // POST api/<AutenticacaoController>
        [HttpPost]
        [Route("login")]
        public ActionResult<AuthResponse> Login([FromBody] LoginRequest request)
        {
            return _mediator.Send(request).Result;
        }
    }
}
