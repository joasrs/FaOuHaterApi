using Aplicacao.Handlers.Comentario.AdicionarComentario;
using Aplicacao.Handlers.Comentario.DeletarComentario;
using Aplicacao.Handlers.Comentario.ObterComentarios;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FaOuHaterApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ComentarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ObterComentariosResponse>> ObterComentarios([FromQuery] ObterComentariosRequest request)
        {
            return _mediator.Send(request).Result;
        }

        [HttpPost]
        public IActionResult AdicionarComentario([FromBody] AdicionarComentarioRequest command)
        {
            return _mediator.Send(command).Result;
        }

        [HttpDelete("{idComentario}")]
        public IActionResult DeleterComentario([FromRoute] int idComentario)
        {
            return _mediator.Send(new DeletarComentarioRequest { IdComentario = idComentario }).Result;
        }
    }
}
