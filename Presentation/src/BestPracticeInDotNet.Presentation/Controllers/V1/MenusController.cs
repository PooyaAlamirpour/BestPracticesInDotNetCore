using BestPracticeInDotNet.Presentation.Api.Controllers.Base;
using BestPracticeInDotNet.Presentation.Api.Models.MenuDto;
using Microsoft.AspNetCore.Mvc;

namespace BestPracticeInDotNet.Presentation.Api.Controllers.V1;

[ApiVersion("1.0")]
public class MenusController : ApiBase
{
    [HttpPost(ApiRoutes.Menu.Create)]
    public IActionResult CreateMenu(CreateMenuRequestDto request, string hostId)
    {
        return Ok(request);
    }
}