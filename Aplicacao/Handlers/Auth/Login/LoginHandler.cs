using Domain.Interfaces;
using Dominio.Enum;
using Dominio.Interfaces.Base;
using Infra.Http;
using MediatR;

namespace Aplicacao.Handlers.Auth.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, IHttpDataResult<AuthResponse>>
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginHandler(IAuthService authService, IUsuarioRepositorio usuarioRepositorio)
        {
            _authService = authService;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Task<IHttpDataResult<AuthResponse>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Senha))
                    return Task.FromResult(HttpDataResult<AuthResponse>.InvalidInput("Campos de login e senha são obrigatórios."));

                var usuario = _usuarioRepositorio.ObterPorLogin(request.Login);

                if (usuario == null || !_authService.ValidarSenha(request.Senha, usuario.Senha))
                    return Task.FromResult(HttpDataResult<AuthResponse>.CreateStatusCode(EnumHttpStatusCode.Unauthorized));

                return Task.FromResult(HttpDataResult<AuthResponse>.Ok(new AuthResponse(_authService.GerarToken(usuario))));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
    }
}
