using BestPracticeInDotNet.Application.Queries.Repositories;
using BestPracticeInDotNet.Infrastructure.Persistence.DbContexts;
using BestPracticeInDotNet.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BestPracticeInDotNet.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddReadInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationReadDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("ReadDbConnectionString"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("ReadDbConnectionString"))
            ));

        services.AddRepositories();
        
        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserReadRepository, UserReadRepository>();
        services.AddTransient<ICustomerReadRepository, CustomerReadRepository>();
        services.AddTransient(typeof(IGenericReadRepository<,>), typeof(GenericReadRepository<,>));
    }
}