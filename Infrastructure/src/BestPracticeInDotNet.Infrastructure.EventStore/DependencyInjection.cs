using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Infrastructure.EventStore.Abstracts;
using BestPracticeInDotNet.Infrastructure.EventStore.DbContexts;
using BestPracticeInDotNet.Infrastructure.EventStore.EventBus;
using BestPracticeInDotNet.Infrastructure.EventStore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BestPracticeInDotNet.Infrastructure.EventStore;

public static class DependencyInjection
{
    public static IServiceCollection AddEventStore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationEventDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("EventDbConnectionString"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("EventDbConnectionString"))
            ));
        
        services.AddTransient<IEventDispatcher, EventDispatcher>();
        services.AddRepositories();

        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient(typeof(IEventStoreRepository<,>), typeof(EventStoreRepository<,>));
        services.AddTransient(typeof(IGenericEventRepository<,>), typeof(GenericEventRepository<,>));
    }
}