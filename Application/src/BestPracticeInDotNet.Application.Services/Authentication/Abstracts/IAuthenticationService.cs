using BestPracticeInDotNet.Application.Services.Authentication.ResponseModels;
using ErrorOr;

namespace BestPracticeInDotNet.Application.Services.Authentication.Abstracts;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    ErrorOr<AuthenticationResult> Login(string email, string password);
}