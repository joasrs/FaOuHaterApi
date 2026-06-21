using Aplicacao.Handlers.Track.ObterTrack;
using Aplicacao.Handlers.Track.ObterTracks;
using FaOuHaterApi.Controllers.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FaOuHaterApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TrackController(IMediator mediator) : RestController
{
    [HttpGet]
    public async Task<IActionResult> ObterTrack([FromQuery] ObterTrackRequest request)
    {
        return ActionResult(await mediator.Send(request));
    }

    [HttpGet("search")]
    public async Task<IActionResult> ObterTracks([FromQuery] ObterTracksRequest request)
    {
        return ActionResult(await mediator.Send(request));
    }
}
