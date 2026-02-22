using Dominio.Interfaces.Base;
using MediatR;

namespace Aplicacao.Handlers.Review.AdicionarReview
{
    public class AdicionarReviewRequest : IRequest<IHttpResult>
    {
        public string Artista { get; set; } = null!;
        public string Musica { get; set; } = null!;
        public string Review { get; set; } = null!;
    }
}
