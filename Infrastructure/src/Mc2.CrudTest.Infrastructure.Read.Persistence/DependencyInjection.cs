using Mc2.CrudTest.Infrastructure.Persistence.DbContexts;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static void AddReadInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationReadDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("ReadDbConnectionString"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("ReadDbConnectionString"))
            ));

        services.AddRepositories();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICustomerReadRepository, CustomerReadReadRepository>();
        services.AddTransient(typeof(IGenericReadRepository<,>), typeof(GenericReadRepository<,>));
    }
}