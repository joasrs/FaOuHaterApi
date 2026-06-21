using Dominio.Interfaces.Base;
using MediatR;

namespace Aplicacao.Handlers.Track.ObterTrack;

public class ObterTrackRequest : IRequest<IHttpDataResult<TrackResponse>>
{
    public Guid? IdTrack { get; set; }
    public string? Track { get; set; } = string.Empty;
    public string? Artist { get; set; } = string.Empty;

    public ObterTrackRequest()
    {
    }

    public ObterTrackRequest(Guid? idTrack, string? track, string? artist)
    {
        IdTrack = idTrack;
        Track = track;
        Artist = artist;
    }
}
