using Aplicacao.Handlers.Auth.CadastrarUsuario;
using Aplicacao.Services;
using Aplicacao.Services.Auth;
using Domain.Interfaces;
using Dominio.Dtos.Review;
using Dominio.Interfaces;
using Dominio.Interfaces.Base;
using Infra.Context;
using Infra.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbFaOuHaterContext>( options =>
    options.UseNpgsql( builder.Configuration.GetConnectionString( "DefaultConnection" ) ) );

builder.Services.AddCors( options =>
{
    options.AddPolicy( "OrigensPermitidas", policy =>
    {
        policy.WithOrigins( "http://localhost:3000" )
               //AllowAnyOrigin()  // Permite qualquer origem
              .AllowAnyMethod()  // Permite qualquer método HTTP (GET, POST, etc.)
              .AllowAnyHeader(); // Permite qualquer cabeçalho
    } );
} );

builder.Services.AddScoped<IServiceBase<ReviewRequisicaoDto, ReviewRespostaDto>, ReviewService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IUsuarioContext, UsuarioContext>();

var key = Encoding.ASCII.GetBytes( "1wish-you-were-here2" );

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer( options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    } );

builder.Services.AddAuthorization();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CadastrarUsuarioHandler).Assembly));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors( "OrigensPermitidas" );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
