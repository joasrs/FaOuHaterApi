using FaOuHaterApi.Interfaces.Base;
using FaOuHaterApi.Models;
using FaOuHaterApi.Models.Context;
using FaOuHaterApi.Models.DTOs.Review;
using FaOuHaterApi.Services;
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

var key = Encoding.ASCII.GetBytes( "1wish-you-were-here2" );

builder.Services.AddAuthentication( options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
} )
.AddJwtBearer( options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "FaOuHaterApi",
        ValidAudience = "fa_ou_hater.frontend",
        IssuerSigningKey = new SymmetricSecurityKey( key )
    };
} );

builder.Services.AddAuthorization();

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
