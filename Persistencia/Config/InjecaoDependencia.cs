using Domain.Interfaces;
using Dominio.Interfaces;
using Infra.Context;
using Infra.Repositorios;
using Infra.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Config
{
    public static class InjecaoDependencia
    {
        public static void AddInjecaoDependecia(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IReviewRepositorio, ReviewRepositorio>();
            services.AddScoped<IComentarioRepositorio, ComentarioRepositorio>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUsuarioContext, UsuarioContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
