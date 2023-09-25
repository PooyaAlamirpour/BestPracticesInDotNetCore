using BestPracticeInDotNet.Application.Queries.Repositories;
using BestPracticeInDotNet.Domain.SubDomain.Errors;
using BestPracticeInDotNet.Infrastructure.Authentication.Authentication;
using ErrorOr;
using MediatR;

namespace BestPracticeInDotNet.Application.Queries.Authentication.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<LoginQueryResponse>>
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    
    public LoginQueryHandler(IUserReadRepository userReadRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userReadRepository = userReadRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<LoginQueryResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.GetByEmailAsync(request.Email);
        if (user is null) return Errors.Authentication.UserLoginFailedException;
        
        if (user.Password == request.Password)
        {
            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
            return new LoginQueryResponse(user.Id, user.FirstName, user.LastName, user.Email, token);    
        }

        return Errors.Authentication.UserLoginFailedException;
    }
}