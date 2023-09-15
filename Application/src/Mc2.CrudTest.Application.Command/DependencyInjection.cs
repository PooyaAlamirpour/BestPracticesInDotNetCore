using System.Reflection;
using FluentValidation;
using Mc2.CrudTest.Application.Command.Customer.Delete;
using Mc2.CrudTest.framework.Mediator.Behaviors;
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

        return services;
    }
}