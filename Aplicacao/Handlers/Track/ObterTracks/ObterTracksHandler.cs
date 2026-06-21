using Dominio.Interfaces.Base;
using Dominio.Interfaces.ExternalServices;
using Infra.Http;
using MediatR;

namespace Aplicacao.Handlers.Track.ObterTracks;

public class ObterTracksHandler(ITrackService trackService) : IRequestHandler<ObterTracksRequest, IHttpDataResult<IEnumerable<TrackResponse>>>
{
    public async Task<IHttpDataResult<IEnumerable<TrackResponse>>> Handle(ObterTracksRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if(string.IsNullOrWhiteSpace(request.Track))
                return await Task.FromResult(HttpDataResult<IEnumerable<TrackResponse>>.BadRequest("O nome da track não pode ser vazio."));

            var tracks = await trackService.ObterTracksAsync(request.Track, cancellationToken);

            return await Task.FromResult(HttpDataResult<IEnumerable<TrackResponse>>.Ok(tracks.Select(track => new TrackResponse(
                track,
                track.Artist,
                string.Empty))));
        }
        catch (Exception ex)
        {
            return await Task.FromResult(HttpDataResult<IEnumerable<TrackResponse>>.InternalServerError(ex));
        }
    }
}
