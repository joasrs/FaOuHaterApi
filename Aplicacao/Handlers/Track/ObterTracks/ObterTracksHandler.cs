using Dominio.Interfaces.Base;
using Infra.ExternalServices.Interfaces;
using Infra.Http;
using MediatR;

namespace Aplicacao.Handlers.Track.ObterTracks;

public class ObterTracksHandler(ITrackService trackService) : IRequestHandler<ObterTracksRequest, IHttpDataResult<IEnumerable<ObterTracksResponse>>>
{
    public async Task<IHttpDataResult<IEnumerable<ObterTracksResponse>>> Handle(ObterTracksRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if(string.IsNullOrWhiteSpace(request.Track))
                return await Task.FromResult(HttpDataResult<IEnumerable<ObterTracksResponse>>.BadRequest("O nome da track não pode ser vazio."));

            var tracks = await trackService.ObterTracksPorNomeAsync(request.Track);

            return await Task.FromResult(HttpDataResult<IEnumerable<ObterTracksResponse>>.Ok(tracks.Select(t => new ObterTracksResponse
            {
                Mbid = t.Mbid,
                Name = t.Name,
                Artist = t.Artist
            })));
        }
        catch (Exception ex)
        {
            return await Task.FromResult(HttpDataResult<IEnumerable<ObterTracksResponse>>.InternalServerError(ex));
        }
    }
}
