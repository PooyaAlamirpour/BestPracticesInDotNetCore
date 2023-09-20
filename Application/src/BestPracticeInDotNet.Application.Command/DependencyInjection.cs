using System.Reflection;
using FluentValidation;
using Mc2.CrudTest.Application.Command.Customer.Delete;
using Mc2.CrudTest.Application.Command.EventHandlers;
using Mc2.CrudTest.Domain.Core.Events;
using Mc2.CrudTest.framework.Mediator.Abstracts;
using Mc2.CrudTest.framework.Mediator.Behaviors;
using Mc2.CrudTest.Infrastructure.EventStore;
using Mc2.CrudTest.Infrastructure.EventStore.Abstracts;
using Mc2.CrudTest.Infrastructure.EventStore.Repositories;
using Mc2.CrudTest.Infrastructure.EventStore.Repositories.Abstracts;
using Mc2.CrudTest.Infrastructure.Write.Persistence.Repository;
using Mc2.CrudTest.Infrastructure.Write.Persistence.Repository.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Application.Command;

public static class DependencyInjection
{
    public static IServiceCollection AddCommandPipeline(this IServiceCollection services, Assembly assembly)
    {
        services.AddTransient<IValidator<DeleteCustomerCommand>, DeleteCustomerCommandValidator>();
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly)
                .AddOpenBehavior(typeof(ValidationBehavior<,>))
                .AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
        
        services.AddRepositories();
        
        return services;
    }
    
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICustomerWriteRepository, CustomerWriteRepository>();
        services.AddTransient(typeof(IEventStoreRepository<,>), typeof(EventStoreRepository<,>));
        services.AddTransient(typeof(Infrastructure.Persistence.Repositories.Abstracts.IGenericReadRepository<,>), 
            typeof(Infrastructure.Persistence.Repositories.GenericReadRepository<,>));
    }
}