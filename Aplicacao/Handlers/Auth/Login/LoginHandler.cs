using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Auth.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, ActionResult<AuthResponse>>
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginHandler(IAuthService authService, IUsuarioRepositorio usuarioRepositorio)
        {
            _authService = authService;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Task<ActionResult<AuthResponse>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Senha))
                    return Task.FromResult<ActionResult<AuthResponse>>(new BadRequestObjectResult("Campos de login e senha são obrigatórios."));

                var usuario = _usuarioRepositorio.ObterPorLogin(request.Login);

                if (usuario == null || !_authService.ValidarSenha(request.Senha, usuario.Senha))
                    return Task.FromResult<ActionResult<AuthResponse>>(new UnauthorizedResult());

                return Task.FromResult<ActionResult<AuthResponse>>(new AuthResponse(_authService.GerarToken(usuario)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
    }
}
