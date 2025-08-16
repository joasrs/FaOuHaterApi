using Dominio.Dtos.Review;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Review.ObterReviews
{
    public class ObterReviewsRequest : IRequest<ActionResult<IEnumerable<ReviewRespostaDto>>>
    {
    }
}
