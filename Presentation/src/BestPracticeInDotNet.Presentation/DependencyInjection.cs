using BestPracticeInDotNet.Presentation.Server.Commons.Convertors;
using BestPracticeInDotNet.Presentation.Server.Commons.Errors;
using BestPracticeInDotNet.Presentation.Server.Controllers.Base;
using BestPracticeInDotNet.Presentation.Server.Filters;
using BestPracticeInDotNet.Presentation.Server.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace BestPracticeInDotNet.Presentation.Server;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        // services.AddScoped<ExceptionHandlingMiddleware>();
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

        services.AddTransient<IConvertor, Convertor>();
        services.AddSingleton<ProblemDetailsFactory, ApplicationProblemDetailsFactory>();
        return services;
    }
}