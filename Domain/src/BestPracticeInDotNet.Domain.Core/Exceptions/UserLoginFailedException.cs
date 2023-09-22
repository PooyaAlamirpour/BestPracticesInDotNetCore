using System.Net;
using BestPracticeInDotNet.Domain.Core.Exceptions.ABstracts;

namespace BestPracticeInDotNet.Domain.Core.Exceptions;

public class UserLoginFailedException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
    public string ErrorMessage => "The requested user can not be logged in.";
}