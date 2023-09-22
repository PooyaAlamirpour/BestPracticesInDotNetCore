using BestPracticeInDotNet.Application.Command.Authentication.Register;
using BestPracticeInDotNet.Application.Queries.Authentication.Login;
using BestPracticeInDotNet.Application.Queries.User.Get;
using BestPracticeInDotNet.Domain.Core.User;
using BestPracticeInDotNet.Presentation.Contracts.Authentication;
using BestPracticeInDotNet.Presentation.Server.Commons.Convertors;
using BestPracticeInDotNet.Presentation.Server.Commons.Models;
using BestPracticeInDotNet.Presentation.Server.Controllers.Base;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BestPracticeInDotNet.Presentation.Server.Controllers.V1;

[Route("auth")]
public class AuthenticationController : ApiBase
{
    private readonly IMediator _sender;
    private readonly IConvertor _convertor;

    public AuthenticationController(IConvertor convertor, IMediator sender)
    {
        _convertor = convertor;
        _sender = sender;
    }

    [HttpPost(ApiRoutes.Authentication.Register)]
    public async Task<IActionResult> Register(RegisterRequestDto requestDto)
    {
        var user = await _sender.Send(new GetUserQuery(requestDto.Email));
        if (!user.IsError)
        {
            var command = new RegisterCommand(
                requestDto.FirstName,
                requestDto.LastName,
                requestDto.Email,
                requestDto.Password);
        
            var registerResult = await _sender.Send(command);
            return registerResult.Match(
                _ => Ok(_convertor.ToDto(registerResult.Value)),
                Problem);
        }

        return user.Match(_ => NotFound(), Problem);
    }

    [HttpPost(ApiRoutes.Authentication.Login)]
    public async Task<IActionResult> Login(LoginRequestDto requestDto)
    {
        var query = new LoginQuery(requestDto.Email, requestDto.Password);
        ErrorOr<LoginQueryResponse> authResult = await _sender.Send(query);

        return authResult.Match(
            _ => Ok(_convertor.ToDto(authResult.Value)),
            Problem);
    }
}