using Newtonsoft.Json;

namespace Mc2.CrudTest.Presentation.Server.Middlewares;

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

        var result = JsonConvert.SerializeObject(new
        {
            message = exception.Message,
            isError = true,
            detail = exception.StackTrace
        });

        await context.Response.WriteAsync(result);
    }
}