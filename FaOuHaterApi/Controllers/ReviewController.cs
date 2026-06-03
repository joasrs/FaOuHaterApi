using Aplicacao.Handlers.Reacao.AdicionarAlterarReacao;
using Aplicacao.Handlers.Review.AdicionarReview;
using Aplicacao.Handlers.Review.DeletarReview;
using Aplicacao.Handlers.Review.ObterReviews;
using FaOuHaterApi.Controllers.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FaOuHaterApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReviewController : RestController
{
    public ReviewController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> ObterReviews([FromQuery] ObterReviewsRequest request)
    {
        return ActionResult(await Mediator.Send(request));
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarReview([FromBody] AdicionarReviewRequest request)
    {
        return ActionResult(await Mediator.Send(request));
    }

    [HttpDelete("{idReview}")]
    public async Task<IActionResult> DeletarReview([FromRoute] DeletarReviewRequest request)
    {
        return ActionResult(await Mediator.Send(request));
    }

    [HttpPut("{idReview}/reagir/{tipoReacao}")]
    public async Task<IActionResult> Put([FromRoute] AdicionarAlterarReacaoRequest request)
    {
        return ActionResult(await Mediator.Send(request));
    }
}
