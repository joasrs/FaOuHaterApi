using Dominio.Interfaces.Base;
using Dominio.Interfaces.ExternalServices;
using Infra.Http;
using MediatR;

namespace Aplicacao.Handlers.Track.ObterTrack;

public class ObterTrackHandler(ITrackService trackService) : IRequestHandler<ObterTrackRequest, IHttpDataResult<TrackResponse>>
{
    public async Task<IHttpDataResult<TrackResponse>> Handle(ObterTrackRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.IdTrack) && (string.IsNullOrWhiteSpace(request.Track) || string.IsNullOrWhiteSpace(request.Artist)))
                return await Task.FromResult(HttpDataResult<TrackResponse>.BadRequest("O nome da track e o nome do artista não podem ser vazios."));

            var track = await trackService.ObterTrackAsync(request.IdTrack, request.Track, request.Artist, cancellationToken);

            if (track == null)
                return await Task.FromResult(HttpDataResult<TrackResponse>.NotFound("Track não encontrada."));

            return await Task.FromResult(HttpDataResult<TrackResponse>.Ok(new TrackResponse(
                track, 
                track.Artist?.Name, 
                track.Album?.Image?.FirstOrDefault(i => i.Size == "large")?.Url)));
        }
        catch (Exception ex)
        {
            return await Task.FromResult(HttpDataResult<TrackResponse>.InternalServerError(ex));
        }
    }
}
