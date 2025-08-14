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

        // GET: api/<AutenticacaoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AutenticacaoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

        // PUT api/<AutenticacaoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AutenticacaoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
