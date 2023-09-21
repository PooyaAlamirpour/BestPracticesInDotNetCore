using BestPracticeInDotNet.Presentation.Contracts.Authentication;
using Mc2.CrudTest.Presentation.Server.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers.V1;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost(ApiRoutes.Authentication.Register)]
    public IActionResult Register(RegisterRequest request)
    {
        return Ok(request);
    }
    
    [HttpPost(ApiRoutes.Authentication.Login)]
    public IActionResult Login(LoginRequest request)
    {
        return Ok(request);
    }
}