using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Application.Services.Authentication.Abstracts;
using BestPracticeInDotNet.Application.Services.Authentication.ResponseModels;
using BestPracticeInDotNet.Domain.Core.User;
using ErrorOr;
using MediatR;

namespace BestPracticeInDotNet.Application.Command.Authentication.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<RegisterCommandResponse>>
{
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    
    public RegisterCommandHandler(IUserWriteRepository userWriteRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userWriteRepository = userWriteRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<RegisterCommandResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var newUser = new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };
        _userWriteRepository.Add(newUser);
        
        var token = _jwtTokenGenerator.GenerateToken(newUser.Id, request.FirstName, request.LastName);
        return new RegisterCommandResponse(newUser.Id, request.FirstName, request.LastName, request.Email, token);
    }
}