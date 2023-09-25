using System.Net;

namespace BestPracticeInDotNet.Domain.SubDomain.Exceptions.ABstracts;

public interface IServiceException
{
    HttpStatusCode StatusCode { get; }
    string ErrorMessage { get; }
}