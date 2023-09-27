using BestPracticeInDotNet.framework.Commons.Errors;
using BestPracticeInDotNet.Presentation.Api.Filters;
using BestPracticeInDotNet.Presentation.Api.Mapping;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace BestPracticeInDotNet.Presentation.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers(x => x.Filters.Add<ExceptionHandlingFilterAttribute>());
        services.AddRazorPages();

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
            options.AssumeDefaultVersionWhenUnspecified = true;
        });

        services.AddMapster();
        
        services.AddTransient<IConvertor, Convertor>();
        services.AddSingleton<ProblemDetailsFactory, ApplicationProblemDetailsFactory>();
        return services;
    }
}