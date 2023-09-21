using Microsoft.AspNetCore.Mvc;

namespace BestPracticeInDotNet.Presentation.Server.Controllers.Base;

[ApiController]
[Route("api/v{version:apiVersion}")]
public class ApiBase : ControllerBase
{
    
}