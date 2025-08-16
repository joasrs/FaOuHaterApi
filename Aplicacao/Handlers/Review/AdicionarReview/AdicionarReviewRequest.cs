using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Review.AdicionarReview
{
    public class AdicionarReviewRequest : IRequest<IActionResult>
    {
        public string Artista { get; set; } = null!;
        public string Musica { get; set; } = null!;
        public string Review { get; set; } = null!;
    }
}
