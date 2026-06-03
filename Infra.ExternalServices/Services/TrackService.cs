using Dominio.Dtos.Config;
using Infra.ExternalServices.Interfaces;
using Infra.ExternalServices.Models.Track;
using Microsoft.Extensions.Options;
using System.Text.Json;
using static Infra.ExternalServices.Models.Track.TracksSearchResultDto;

namespace Infra.ExternalServices.Services;

public class TrackService(IHttpClientFactory httpClientFactory, IOptions<ApiConfig> options) : ITrackService
{
    public async Task<IEnumerable<SearchTrackDto>> ObterTracksPorNomeAsync(string nomeTrack)
    {
		try
		{
			var client = httpClientFactory.CreateClient("last.fm");
			var result = await client.GetAsync($"?api_key=???c3&method=track.search&track={nomeTrack}&format=json&limit=5");

			if (result.IsSuccessStatusCode)
			{
				var content = await result.Content.ReadAsStringAsync();
				var tracks = JsonSerializer.Deserialize<TracksSearchResultDto>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
				return tracks?.Results?.TrackMatches?.Track ?? [];
			}

			return [];
        }
		catch (Exception ex)
		{

			throw ex;
		}
    }
}
