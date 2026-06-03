using Dominio.Interfaces.Base;
using MediatR;

namespace Aplicacao.Handlers.Comentario.DeletarComentario;

public class DeletarComentarioRequest : IRequest<IHttpResult>
{
    public int IdComentario { get; set; }
}
