using System.Net;
using BestPracticeInDotNet.Domain.Core.Exceptions.ABstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BestPracticeInDotNet.Presentation.Server.Filters;

public class ExceptionHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        if (exception is null) return;

        var (statusCode, title) = exception switch
        {
            IServiceException serviceException => (serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (HttpStatusCode.InternalServerError, "An unhandled exception is thrown.")
        };
        
        var problemDetails = new ProblemDetails()
        {
            Title = title,
            Instance = context.HttpContext.Request.Path,
            Status = (int)statusCode,
            Detail = $"{exception.Message}. {exception.InnerException?.Message}",
        };

        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}