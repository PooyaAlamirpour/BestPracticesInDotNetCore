using System.Net;
using BestPracticeInDotNet.Domain.Core.Exceptions.ABstracts;

namespace BestPracticeInDotNet.Domain.Core.Exceptions;

public class CustomerNotFoundException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string ErrorMessage => "The requested customer is not found";
}