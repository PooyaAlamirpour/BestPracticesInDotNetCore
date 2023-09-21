using System.Reflection;
using FluentValidation;
using BestPracticeInDotNet.Application.Command.Customer.Delete;
using BestPracticeInDotNet.framework.Mediator.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace BestPracticeInDotNet.Application.Command;

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
    }
}