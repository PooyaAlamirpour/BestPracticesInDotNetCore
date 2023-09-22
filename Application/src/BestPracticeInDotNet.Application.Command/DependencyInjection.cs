using System.Reflection;
using BestPracticeInDotNet.Application.Command.Authentication.Register;
using FluentValidation;
using BestPracticeInDotNet.Application.Command.Customer.Delete;
using BestPracticeInDotNet.framework.Mediator.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace BestPracticeInDotNet.Application.Command;

public static class DependencyInjection
{
    public static IServiceCollection AddCommandPipeline(this IServiceCollection services, Assembly assembly)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly)
                .AddOpenBehavior(typeof(ValidationBehavior<,>))
                .AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddValidatorsFromAssembly(CommandApplicationAssembly.Assembly);
        
        services.AddRepositories();
        
        return services;
    }
    
    private static void AddRepositories(this IServiceCollection services)
    {
    }
}