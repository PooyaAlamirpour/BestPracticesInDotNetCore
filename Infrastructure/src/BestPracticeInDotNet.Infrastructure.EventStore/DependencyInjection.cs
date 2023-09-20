using Mc2.CrudTest.Infrastructure.EventStore.Abstracts;
using Mc2.CrudTest.Infrastructure.EventStore.DbContexts;
using Mc2.CrudTest.Infrastructure.EventStore.EventBus;
using Mc2.CrudTest.Infrastructure.EventStore.Repositories;
using Mc2.CrudTest.Infrastructure.EventStore.Repositories.Abstracts;
using Mc2.CrudTest.Infrastructure.Write.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Infrastructure.EventStore;

public static class DependencyInjection
{
    public static void AddEventStore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationEventDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("EventDbConnectionString"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("EventDbConnectionString"))
            ));
        
        services.AddTransient<IEventDispatcher, EventDispatcher>();
        services.AddRepositories();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient(typeof(IEventStoreRepository<,>), typeof(EventStoreRepository<,>));
        services.AddTransient(typeof(IGenericEventRepository<,>), typeof(GenericEventRepository<,>));
    }
}