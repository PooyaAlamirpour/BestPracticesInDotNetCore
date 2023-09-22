using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Application.Queries.Repositories;
using BestPracticeInDotNet.Application.Services.Authentication.Abstracts;
using BestPracticeInDotNet.Application.Services.Authentication.ResponseModels;
using BestPracticeInDotNet.Domain.Core.Errors;
using BestPracticeInDotNet.Domain.Core.User;
using ErrorOr;

namespace BestPracticeInDotNet.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IUserWriteRepository _userWriteRepository;
    
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, 
        IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        var user = _userReadRepository.Any(x => x.Email == email);
        if (user) return Errors.User.UserRegistrationFailed;
        
        var newUser = new User()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userWriteRepository.Add(newUser);
        
        var token = _jwtTokenGenerator.GenerateToken(newUser.Id, firstName, lastName);
        return new AuthenticationResult(newUser.Id, firstName, lastName, email, token);
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        var user = _userReadRepository.GetByEmailAsync(email).GetAwaiter().GetResult();
        if (user is not null)
        {
            if (user.Password == password)
            {
                var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
                return new AuthenticationResult(user.Id, user.FirstName, user.LastName, user.Email, token);    
            }
        }

        return Errors.Authentication.UserLoginFailedException;
    }
}