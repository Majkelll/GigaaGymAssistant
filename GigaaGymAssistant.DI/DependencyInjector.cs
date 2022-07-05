using GigaaGymAssistant.Domain.Common.Models.User;
using GigaaGymAssistant.Domain.Common.Utils;
using GigaaGymAssistant.Domain.Facades;
using GigaaGymAssistant.Infrastructure.EntityFramework;
using GigaaGymAssistant.Infrastructure.EntityFramework.Entities;
using GigaaGymAssistant.Infrastructure.EntityFramework.Services;
using GigaaGymAssistant.Interfaces.Facades;
using GigaaGymAssistant.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GigaaGymAssistant.Domain.DI;

public static class DependencyInjector
{
    public static void AddDependency(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<GGADbContext>();
        serviceCollection.AddScoped<DbSeeder>();
        serviceCollection.AddScoped<IAccountFcd, AccountFcd>();
        serviceCollection.AddScoped<IAccountSrv, AccountSrv>();
        serviceCollection.AddScoped<IJwtUtils, JwtUtils>();
        serviceCollection.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        var authenticationSettings = new AuthenticationSettings();
        configuration.GetSection("Authentication").Bind(authenticationSettings);

        serviceCollection.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "Bearer";
            options.DefaultScheme = "Bearer";
            options.DefaultChallengeScheme = "Bearer";
        }).AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = authenticationSettings.JwtIssuer,
                ValidAudience = authenticationSettings.JwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
            };
        });
        serviceCollection.AddSingleton(authenticationSettings);
    }
}