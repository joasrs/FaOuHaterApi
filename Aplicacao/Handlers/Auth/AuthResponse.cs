namespace Aplicacao.Handlers.Auth;

public class AuthResponse
{
    public string? Token { get; set; }

    public AuthResponse(string token)
    {
        Token = token;
    }
}
