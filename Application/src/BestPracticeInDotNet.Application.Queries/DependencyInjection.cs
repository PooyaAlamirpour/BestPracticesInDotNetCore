using System.Reflection;
using BestPracticeInDotNet.Application.Queries.Customer.Get;
using BestPracticeInDotNet.Domain.Core.DomainModels.Customer;
using BestPracticeInDotNet.framework.Mediator.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BestPracticeInDotNet.Application.Queries;

public static class DependencyInjection
{
    public static IServiceCollection AddQueryPipeline(this IServiceCollection services, Assembly assembly)
    {
        services.AddTransient<IRequestHandler<GetCustomerQuery, List<CustomerAggregateRoot>>, GetCustomerQueryHandler>();
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly)
                .AddOpenBehavior(typeof(ValidationBehavior<,>))
                .AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
        
        services.AddValidatorsFromAssembly(QueryApplicationAssembly.Assembly);

        return services;
    }
}