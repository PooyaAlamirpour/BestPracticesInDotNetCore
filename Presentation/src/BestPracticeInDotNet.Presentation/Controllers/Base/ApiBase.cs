using System.Net;
using BestPracticeInDotNet.Presentation.Server.Commons.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BestPracticeInDotNet.Presentation.Server.Controllers.Base;

[ApiController]
[Route("api/v{version:apiVersion}")]
public class ApiBase : ControllerBase
{
    public IActionResult Problem(List<Error> errors)
    {
        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(
                    error.Code,
                    error.Description);
            }

            return ValidationProblem(modelStateDictionary);
        }
        
        HttpContext.Items.Add(HttpContextItemKeys.Errors, errors);
        
        var firstError = errors.FirstOrDefault();
        var statusCode = firstError.Type switch
        {
            ErrorType.Failure => HttpStatusCode.InternalServerError,
            ErrorType.Unexpected => HttpStatusCode.InternalServerError,
            ErrorType.Validation => HttpStatusCode.BadRequest,
            ErrorType.Conflict => HttpStatusCode.Conflict,
            ErrorType.NotFound => HttpStatusCode.NotFound,
            _ => HttpStatusCode.InternalServerError
        };
        
        var problem = new ProblemDetails();
        problem.Extensions.Add("ErrorCodes", errors.Select(x => x.Code));

        return Problem(
            statusCode: (int)statusCode, 
            title: firstError.Description);
    }
}