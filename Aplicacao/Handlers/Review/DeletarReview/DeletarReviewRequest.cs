using Dominio.Interfaces.Base;
using MediatR;

namespace Aplicacao.Handlers.Review.DeletarReview
{
    public class DeletarReviewRequest : IRequest<IHttpResult>
    {
        public int IdReview { get; set; }
    }
}
