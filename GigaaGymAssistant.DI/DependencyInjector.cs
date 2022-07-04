using GigaaGymAssistant.Infrastructure.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GigaaGymAssistant.Domain.DI;

public static class DependencyInjector
{
    public static void AddDependency(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<GGADbContext>();
    }
}