using System.Net;
using Newtonsoft.Json;

namespace BestPracticeInDotNet.Presentation.Server.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";
        int code = (int)HttpStatusCode.InternalServerError;
        
        var result = JsonConvert.SerializeObject(new
        {
            Message = exception.Message,
            HasError = true,
            StatusCode = code,
            // Detail = exception.StackTrace
        });
        context.Response.StatusCode = code;
        await context.Response.WriteAsync(result);
    }
}