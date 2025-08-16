using Aplicacao.Handlers.Review.AdicionarReview;
using Aplicacao.Handlers.Review.DeletarReview;
using Aplicacao.Handlers.Review.ObterReviews;
using Dominio.Dtos.Review;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FaOuHaterApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReviewRespostaDto>> ObterReviews()
        {
            return _mediator.Send(new ObterReviewsRequest()).Result;
        }

        [HttpPost]
        public IActionResult ObterReviews([FromBody] AdicionarReviewRequest command)
        {
            return _mediator.Send(command).Result;
        }

        [HttpDelete("{idReview}")]
        public IActionResult DeletarReview([FromRoute] int idReview)
        {
            return _mediator.Send(new DeletarReviewRequest { IdReview = idReview }).Result;
        }
    }
}
