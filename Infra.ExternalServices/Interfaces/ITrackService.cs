using Infra.ExternalServices.Models.Track;
using static Infra.ExternalServices.Models.Track.TracksSearchResultDto;

namespace Infra.ExternalServices.Interfaces;

public interface ITrackService
{
    Task<IEnumerable<SearchTrackDto>> ObterTracksPorNomeAsync(string nomeTrack);
}
