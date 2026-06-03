using Dominio.Interfaces.Base;
using MediatR;

namespace Aplicacao.Handlers.Track.ObterTracks;

public class ObterTracksRequest : IRequest<IHttpDataResult<IEnumerable<ObterTracksResponse>>>
{
    public string Track { get; set; } = string.Empty;
}
