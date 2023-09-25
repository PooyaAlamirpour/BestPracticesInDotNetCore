using System.Reflection;
using BestPracticeInDotNet.Application.Command.Customer.Create;
using BestPracticeInDotNet.Application.Command.Customer.Delete;
using BestPracticeInDotNet.Application.Command.Customer.Update;
using BestPracticeInDotNet.framework.Mediator.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BestPracticeInDotNet.Application.Command;

public static class DependencyInjection
{
    public static IServiceCollection AddCommandPipeline(this IServiceCollection services, Assembly assembly)
    {
        services.AddTransient<IRequestHandler<UpdateCustomerCommand>, UpdateCustomerCommandHandler>() ;
        services.AddTransient<IRequestHandler<DeleteCustomerCommand>, DeleteCustomerCommandHandler>() ;
        services.AddTransient<IRequestHandler<CreateCustomerCommand>, CreateCustomerCommandHandler>() ;
        
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly)
                .AddOpenBehavior(typeof(ValidationBehavior<,>))
                .AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        // services.AddValidatorsFromAssembly(CommandApplicationAssembly.Assembly);
        
        services.AddRepositories();
        
        return services;
    }
    
    private static void AddRepositories(this IServiceCollection services)
    {
    }
}