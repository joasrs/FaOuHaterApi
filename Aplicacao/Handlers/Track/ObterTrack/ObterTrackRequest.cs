using Dominio.Interfaces.Base;
using MediatR;

namespace Aplicacao.Handlers.Track.ObterTrack;

public class ObterTrackRequest : IRequest<IHttpDataResult<TrackResponse>>
{
    public string? IdTrack { get; set; } = string.Empty;
    public string? Track { get; set; } = string.Empty;
    public string? Artist { get; set; } = string.Empty;
}
