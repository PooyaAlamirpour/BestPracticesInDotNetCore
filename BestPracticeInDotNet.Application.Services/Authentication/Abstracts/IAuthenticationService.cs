
using BestPracticeInDotNet.Application.Services.Authentication.ResponseModels;

namespace BestPracticeInDotNet.Application.Services.Authentication.Abstracts;

public interface IAuthenticationService
{
    AuthenticationResult Register(string firstName, string lastName, string email, string password);
    AuthenticationResult Login(string email, string password);
}