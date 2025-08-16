using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Comentario.AdicionarComentario
{
    public class AdicionarComentarioRequest : IRequest<IActionResult>
    {
        public int IdReview { get; set; }
        public string? Comentario { get; set; }
    }
}
