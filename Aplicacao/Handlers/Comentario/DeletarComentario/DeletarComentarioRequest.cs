using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Comentario.DeletarComentario
{
    public class DeletarComentarioRequest : IRequest<IActionResult>
    {
        public int IdComentario { get; set; }
    }
}
