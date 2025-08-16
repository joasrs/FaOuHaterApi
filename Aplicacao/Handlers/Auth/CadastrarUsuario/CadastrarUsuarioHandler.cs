using Domain.Interfaces;
using Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Auth.CadastrarUsuario
{
    public class CadastrarUsuarioHandler : IRequestHandler<CadastrarUsuarioRequest, ActionResult<AuthResponse>>
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public CadastrarUsuarioHandler(IAuthService authService, IUsuarioRepositorio usuarioRepositorio)
        {
            _authService = authService;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Task<ActionResult<AuthResponse>> Handle(CadastrarUsuarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Nome) || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Senha))
                    return Task.FromResult<ActionResult<AuthResponse>>(new BadRequestObjectResult("Todos os campos são obrigatórios."));

                if (_usuarioRepositorio.VerificarUsuarioExiste(request.Login, request.Email))
                    return Task.FromResult<ActionResult<AuthResponse>>(new BadRequestObjectResult("Usuário ou e-mail já cadastrado."));

                var usuario = new Usuario
                {
                    Nome = request.Nome,
                    Email = request.Email,
                    Login = request.Login,
                    Senha = _authService.Hash(request.Senha)
                };

                _usuarioRepositorio.Add(usuario);
                _usuarioRepositorio.SalvarAlteracaoes();

                return Task.FromResult<ActionResult<AuthResponse>>(new OkObjectResult(_authService.GerarToken(usuario)));
            }
            catch (Exception ex)
            {
                return Task.FromResult<ActionResult<AuthResponse>>(new ObjectResult(new { Error = ex.Message }) { StatusCode = 500 });
            }
        }
    }
}
