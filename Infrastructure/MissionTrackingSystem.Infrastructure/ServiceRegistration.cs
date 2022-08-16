using Microsoft.Extensions.DependencyInjection;
using MissionTrackingSystem.Infrastructure.Services.Token;

namespace MissionTrackingSystem.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<Application.Abstractions.Token.ITokenHandler, TokenHandler>();
        }
    }
}
