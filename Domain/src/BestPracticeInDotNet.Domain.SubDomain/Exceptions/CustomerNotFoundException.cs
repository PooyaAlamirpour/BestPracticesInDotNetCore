using System.Net;
using BestPracticeInDotNet.Domain.SubDomain.Exceptions.ABstracts;

namespace BestPracticeInDotNet.Domain.SubDomain.Exceptions;

public class CustomerNotFoundException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string ErrorMessage => "The requested customer is not found";
}