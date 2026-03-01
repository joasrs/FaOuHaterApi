using Dominio.Interfaces.Base;
using MediatR;

namespace Aplicacao.Handlers.Comentario.AdicionarComentario;

public class AdicionarComentarioRequest : IRequest<IHttpResult>
{
    public int IdReview { get; set; }
    public string? Comentario { get; set; }
}
