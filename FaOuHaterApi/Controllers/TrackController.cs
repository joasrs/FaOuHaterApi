using Aplicacao.Handlers.Review.ObterReviews;
using Aplicacao.Handlers.Track.ObterTracks;
using FaOuHaterApi.Controllers.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FaOuHaterApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : RestController
    {
        public TrackController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("search")]
        public async Task<IActionResult> ObterTracks([FromQuery] ObterTracksRequest request)
        {
            return ActionResult(await Mediator.Send(request));
        }
    }
}
