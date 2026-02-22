using Dominio.Interfaces.Base;
using MediatR;

namespace Aplicacao.Handlers.Comentario.ObterComentarios
{
    public class ObterComentariosRequest : IRequest<IHttpDataResult<IEnumerable<ObterComentariosResponse>>>
    {
        public int IdReview { get; set; }
    }
}
