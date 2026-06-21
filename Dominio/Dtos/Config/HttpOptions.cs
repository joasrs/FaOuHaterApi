namespace Dominio.Dtos.Config;

public class HttpOptions
{
    public ApiConfig? LastFm { get; set; }
}

public class ApiConfig
{
    public string? BaseUrl { get; set; }
    public string? Key { get; set; }
}
