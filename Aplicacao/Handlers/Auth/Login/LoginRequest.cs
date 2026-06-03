using Dominio.Interfaces.Base;
using MediatR;

namespace Aplicacao.Handlers.Auth.Login;

public class LoginRequest : IRequest<IHttpDataResult<AuthResponse>>
{
    public string Login { get; set; } = null!;

    public string Senha { get; set; } = null!;
}