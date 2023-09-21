using BestPracticeInDotNet.Application.Services.Authentication.Abstracts;
using BestPracticeInDotNet.Application.Services.DateTimeProvider;
using BestPracticeInDotNet.Infrastructure.Authentication.Authentication;
using BestPracticeInDotNet.Infrastructure.Authentication.DatetimeProvider;
using Microsoft.Extensions.DependencyInjection;

namespace BestPracticeInDotNet.Infrastructure.Authentication;

public static class DependencyInjection
{
    public static IServiceCollection AddJwtTokenGenerator(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}