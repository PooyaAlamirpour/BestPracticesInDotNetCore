using BestPracticeInDotNet.Application.Services.DateTimeProvider;
using BestPracticeInDotNet.Infrastructure.Authentication.Authentication;
using BestPracticeInDotNet.Infrastructure.Authentication.DatetimeProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BestPracticeInDotNet.Infrastructure.Authentication;

public static class DependencyInjection
{
    public static IServiceCollection AddJwtTokenGenerator(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}