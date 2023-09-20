using System.Reflection;
using FluentValidation;
using Mc2.CrudTest.Application.Queries.Customer.Get;
using Mc2.CrudTest.Domain.Core.Customer;
using Mc2.CrudTest.framework.Mediator.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Application.Queries;

public static class DependencyInjection
{
    public static IServiceCollection AddQueryPipeline(this IServiceCollection services, Assembly assembly)
    {
        services.AddTransient<IValidator<GetCustomerQuery>, GetCustomerQueryValidator>();
        services.AddTransient<IRequestHandler<GetCustomerQuery, List<CustomerAggregateRoot>>, GetCustomerQueryHandler>();
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly)
                .AddOpenBehavior(typeof(ValidationBehavior<,>))
                .AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        return services;
    }
}