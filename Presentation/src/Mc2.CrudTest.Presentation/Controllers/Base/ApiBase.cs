using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers.Base;

[ApiController]
[Route("api/v{version:apiVersion}")]
public class ApiBase : ControllerBase
{
    
}