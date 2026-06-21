using Dominio.Interfaces;
using Dominio.Interfaces.ExternalServices;
using Infra.Context;
using Infra.ExternalServices.Services;
using Infra.Repositorios;
using Infra.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Config;

public static class InjecaoDependencia
{
    public static void AddInjecaoDependecia(this IServiceCollection services)
    {
        services.AddScoped<IComentarioRepositorio, ComentarioRepositorio>();
        services.AddScoped<IReacaoRepositorio, ReacaoRepositorio>();
        services.AddScoped<IReviewRepositorio, ReviewRepositorio>();
        services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        services.AddScoped<IUsuarioContext, UsuarioContext>();

        services.AddSingleton<ITrackService, TrackService>();
        services.AddSingleton<IAuthService, AuthService>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}
