using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Comentario.ObterComentarios
{
    public class ObterComentariosRequest : IRequest<ActionResult<IEnumerable<ObterComentariosResponse>>>
    {
        public int IdReview { get; set; }
    }
}
