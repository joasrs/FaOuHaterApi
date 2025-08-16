using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Review.DeletarReview
{
    public class DeletarReviewRequest : IRequest<IActionResult>
    {
        public int IdReview { get; set; }
    }
}
