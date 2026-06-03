namespace Infra.ExternalServices.Models.Track;

public class InfoTrackDto : BaseTrackDto
{
    public string? Duration { get; set; }
    public StreamableDto? Streamable { get; set; }
    public string? Playcount { get; set; }
    public ArtistDto? Artist { get; set; }
    public AlbumDto? Album { get; set; }
    public TopTagsDto? TopTags { get; set; }
    public WikiDto? Wiki { get; set; }

    public class StreamableDto
    {
        public string? Text { get; set; }
        public string? Fulltrack { get; set; }
    }

    public class ArtistDto
    {
        public string? Name { get; set; }
        public string? Mbid { get; set; }
        public string? Url { get; set; }
    }

    public class AlbumDto
    {
        public string? Artist { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public List<ImageDto>? Image { get; set; }
    }

    public class TopTagsDto
    {
        public List<TagDto>? Tag { get; set; }
    }

    public class TagDto
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
    }

    public class WikiDto
    {
        public string? Published { get; set; }
        public string? Summary { get; set; }
        public string? Content { get; set; }
    }
}
