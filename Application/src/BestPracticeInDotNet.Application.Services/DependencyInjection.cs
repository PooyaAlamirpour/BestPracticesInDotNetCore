using BestPracticeInDotNet.Application.Services.Authentication;
using BestPracticeInDotNet.Application.Services.Authentication.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace BestPracticeInDotNet.Application.Services;


public static class DependencyInjection
{
    public static IServiceCollection AddAuthenticationService(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}