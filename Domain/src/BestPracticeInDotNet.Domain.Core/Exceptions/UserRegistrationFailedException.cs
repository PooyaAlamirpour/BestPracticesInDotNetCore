using System.Net;
using BestPracticeInDotNet.Domain.Core.Exceptions.ABstracts;

namespace BestPracticeInDotNet.Domain.Core.Exceptions;

public class UserRegistrationFailedException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public string ErrorMessage => "The requested user can not be registered.";
}