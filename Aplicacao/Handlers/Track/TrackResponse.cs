using Dominio.Dtos.ExternalServices.Track;

namespace Aplicacao.Handlers.Track;

public class TrackResponse
{
    public Guid? IdTrack { get; set; }
    public string? Name { get; set; }
    public string? Artist { get; set; }
    public string? ImageUrl { get; set; }

    public TrackResponse(BaseTrackDto track, string? artist, string? url)
    {
        if(!string.IsNullOrEmpty(track.Mbid) && Guid.TryParse(track.Mbid, out var guid))
            IdTrack = guid;

        Name = track.Name;
        Artist = artist;
        ImageUrl = url;
    }
}
