using GigaaGymAssistant.Domain.Common.Models.User;
using GigaaGymAssistant.Infrastructure.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace GigaaGymAssistant.Domain.DI;

public static class DependencyInjector
{
    public static void AddDependency(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<GGADbContext>();
        serviceCollection.AddScoped<DbSeeder>();

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
    }
}