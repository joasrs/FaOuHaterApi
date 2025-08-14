using Domain.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infra.Context
{
    public class UsuarioContext : IUsuarioContext
    {
        private readonly Usuario _usuarioLogado;

        public Usuario Usuario { get => _usuarioLogado; }

        public UsuarioContext(IUsuarioRepositorio usuarioRepositorio, IHttpContextAccessor httpContextAccessor)
        {
            _usuarioLogado = usuarioRepositorio.Obter(int.Parse(httpContextAccessor.HttpContext.User.Identity!.Name!))!;
        }
    }
}
