using Dominio.Dtos.Config;
using Dominio.Dtos.ExternalServices.Track;
using Dominio.Interfaces.ExternalServices;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;
using static Dominio.Dtos.ExternalServices.Track.InfoTrackResultDto;
using static Dominio.Dtos.ExternalServices.Track.TracksSearchResultDto;

namespace Infra.ExternalServices.Services;

public class TrackService(ILogger<TrackService> logger, IHttpClientFactory httpClientFactory, IOptions<HttpOptions> httpOptions) : ITrackService
{
    public async Task<InfoTrackDto?> ObterTrackAsync(string? idTrack, string? track, string? artist, CancellationToken cancellationToken)
    {
        var trackResult = await RequestExternal<InfoTrackResultDto>(
            cancellationToken,
            "track.getInfo",
            idTrack,
            track,
            artist);

        return trackResult?.Track;
    }

    public async Task<IEnumerable<SearchTrackDto>> ObterTracksAsync(string track, CancellationToken cancellationToken)
    {
        var tracksSearchResult = await RequestExternal<TracksSearchResultDto>(
            cancellationToken, 
            "track.search", 
            track: track);

        return tracksSearchResult?.Results?.TrackMatches?.Track ?? [];
    }

    public async Task<T?> RequestExternal<T>(
        CancellationToken cancellationToken,
        string method, 
        string? idTrack = null,
        string? track = null, 
        string? artist = null)
    {
        try
        {
            var client = httpClientFactory.CreateClient("last.fm");

            var query = new Dictionary<string, string>
            {
                ["method"] = method,
                ["format"] = "json",
                ["limit"] = "5",
                ["mbid"] = idTrack ?? string.Empty,
                ["track"] = track ?? string.Empty,
                ["artist"] = artist ?? string.Empty,
                ["api_key"] = httpOptions?.Value?.LastFm?.Key ?? string.Empty,
            };

            var url = QueryHelpers.AddQueryString("", query);
            var response = await client.GetAsync(url, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? default;
            }
        }
        catch (JsonException ex)
        {
            logger.LogError("Erro ocorrido ao desserializar o retorno da requisição externa: {erro}. StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
        }
        catch (Exception ex)
        {
            logger.LogError("Erro ocorrido ao executar requisição externa: {erro}. StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
        }

        return default;
    }
}
