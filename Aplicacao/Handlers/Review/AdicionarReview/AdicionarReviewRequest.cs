using Dominio.Interfaces.Base;
using MediatR;

namespace Aplicacao.Handlers.Review.AdicionarReview
{
    public class AdicionarReviewRequest : IRequest<IHttpResult>
    {
        public Guid? IdTrack { get; set; }
        public string Artista { get; set; } = string.Empty;
        public string Musica { get; set; } = string.Empty;
        public string Review { get; set; } = string.Empty;
    }
}
