using BestPracticeInDotNet.Application.Services.Authentication.Abstracts;
using BestPracticeInDotNet.Application.Services.Authentication.ResponseModels;
using BestPracticeInDotNet.Presentation.Contracts.Authentication;
using BestPracticeInDotNet.Presentation.Server.Commons.Convertors;
using BestPracticeInDotNet.Presentation.Server.Controllers.Base;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BestPracticeInDotNet.Presentation.Server.Controllers.V1;

[Route("auth")]
public class AuthenticationController : ApiBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IConvertor _convertor;

    public AuthenticationController(IAuthenticationService authenticationService, IConvertor convertor)
    {
        _authenticationService = authenticationService;
        _convertor = convertor;
    }

    [HttpPost(ApiRoutes.Authentication.Register)]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> registerResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        return registerResult.Match(
            _ => Ok(_convertor.ToDto(registerResult.Value)),
            Problem);
    }

    [HttpPost(ApiRoutes.Authentication.Login)]
    public IActionResult Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authenticationService.Login(
            request.Email,
            request.Password);

        return authResult.Match(
            _ => Ok(_convertor.ToDto(authResult.Value)),
            Problem);
    }
}