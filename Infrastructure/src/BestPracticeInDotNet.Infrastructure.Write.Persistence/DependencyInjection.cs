using Mc2.CrudTest.Application.Command.Repositories;
using Mc2.CrudTest.Infrastructure.Write.Persistence.DbContexts;
using Mc2.CrudTest.Infrastructure.Write.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Infrastructure.Write.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddWriteInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationWriteDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("WriteDbConnectionString"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("WriteDbConnectionString"))
            ));

        services.AddRepositories();

        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICustomerWriteRepository, CustomerWriteRepository>();
        services.AddTransient(typeof(IGenericWriteRepository<,>), typeof(GenericWriteRepository<,>));
    }
}