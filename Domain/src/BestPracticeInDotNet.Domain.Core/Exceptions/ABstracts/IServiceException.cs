using System.Net;

namespace BestPracticeInDotNet.Domain.Core.Exceptions.ABstracts;

public interface IServiceException
{
    HttpStatusCode StatusCode { get; }
    string ErrorMessage { get; }
}