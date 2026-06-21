using System.Text.Json.Serialization;

namespace Dominio.Dtos.ExternalServices.Track;

public class BaseTrackDto
{
    public string? Mbid { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
    public string? Listeners { get; set; }
}

public class ImageDto
{
    [JsonPropertyName("#text")]
    public string? Url { get; set; }
    public string? Size { get; set; }
}