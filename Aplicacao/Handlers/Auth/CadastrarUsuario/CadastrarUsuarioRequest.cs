using Dominio.Interfaces.Base;
using MediatR;

namespace Aplicacao.Handlers.Auth
{
    public class CadastrarUsuarioRequest : IRequest<IHttpDataResult<AuthResponse>>
    {
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }
}
