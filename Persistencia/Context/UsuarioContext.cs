using Domain.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infra.Context;

public class UsuarioContext : IUsuarioContext
{
    private readonly Usuario? _usuarioLogado;

    public Usuario? Usuario { get => _usuarioLogado; }

    public UsuarioContext(IUsuarioRepositorio usuarioRepositorio, IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor?.HttpContext?.User;
        _usuarioLogado = (!user?.Identity?.IsAuthenticated ?? false) ? null : usuarioRepositorio.Obter(int.Parse(user!.Identity!.Name!))!;
    }
}
