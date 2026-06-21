using static Dominio.Dtos.ExternalServices.Track.InfoTrackResultDto;
using static Dominio.Dtos.ExternalServices.Track.TracksSearchResultDto;

namespace Dominio.Interfaces.ExternalServices;

public interface ITrackService
{
    Task<InfoTrackDto?> ObterTrackAsync(Guid? idTrack, string? track, string? artist, CancellationToken cancellationToken);
    Task<IEnumerable<SearchTrackDto>> ObterTracksAsync(string track, CancellationToken cancellationToken);
}
