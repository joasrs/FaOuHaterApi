namespace Infra.ExternalServices.Models.Track;

public class TracksSearchResultDto
{
    public ResultsDto? Results { get; set; }
    public class ResultsDto
    {
        public TrackMatchesDto? TrackMatches { get; set; }
    }
    public class TrackMatchesDto
    {
        public List<SearchTrackDto>? Track { get; set; }
    }

    public class SearchTrackDto : BaseTrackDto
    {
        public string? Artist { get; set; }
        public string? Streamable { get; set; }
        public List<ImageDto>? Image { get; set; }
    }
}
