using Intranet.Application.Contracts.Persistence;
using Intranet.Persistence.DataBaseContext;
using Intranet.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Intranet.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
    IConfiguration configuration)
    {
        services.AddDbContext<IntranetDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("IntranetDatabase"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<INewsRepository, NewsRepository>();
        services.AddScoped<IEmployeeDirectoryRepository, EmployeeDirectoryRepository>();
        return services;
    }
}
