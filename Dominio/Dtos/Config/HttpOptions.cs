namespace Dominio.Dtos.Config;

public class HttpOptions
{
    public HttpConfig Http { get; set; } = new();
}

public class HttpConfig
{
    public ApiConfig LastFm { get; set; } = new();
}

public class ApiConfig
{
    public string BaseUrl { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
}
