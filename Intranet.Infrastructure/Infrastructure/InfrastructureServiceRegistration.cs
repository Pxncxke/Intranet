using Intranet.Application.Contracts.Logging;
using Intranet.Infrastructure.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Intranet.Infrastructure.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
    IConfiguration configuration)
    {
        services.AddScoped(typeof(ILoggerManager<>), typeof(LoggerManager<>));
        return services;
    }
}
