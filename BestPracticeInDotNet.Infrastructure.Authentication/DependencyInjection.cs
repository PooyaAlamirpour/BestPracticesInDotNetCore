using BestPracticeInDotNet.Application.Services.Authentication.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace BestPracticeInDotNet.Infrastructure.Authentication;

public static class DependencyInjection
{
    public static IServiceCollection AddJwtTokenGenerator(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}