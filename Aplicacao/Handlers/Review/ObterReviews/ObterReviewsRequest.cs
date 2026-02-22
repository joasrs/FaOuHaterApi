using Dominio.Dtos.Review;
using Dominio.Interfaces.Base;
using MediatR;

namespace Aplicacao.Handlers.Review.ObterReviews
{
    public class ObterReviewsRequest : IRequest<IHttpDataResult<IEnumerable<ReviewRespostaDto>>>
    {
    }
}
