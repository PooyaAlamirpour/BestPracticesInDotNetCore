using Mc2.CrudTest.framework.Mediator.Abstracts;
using Mc2.CrudTest.Infrastructure.Persistence.DbContexts;
using Mc2.CrudTest.Infrastructure.Persistence.EventBus;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DbConnectionString"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("DbConnectionString"))
            ));

        services.AddTransient<IEventDispatcher, EventDispatcher>();
        
        services.AddRepositories();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient(typeof(IEventStoreRepository<,>), typeof(EventStoreRepository<,>));
        services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
    }
}