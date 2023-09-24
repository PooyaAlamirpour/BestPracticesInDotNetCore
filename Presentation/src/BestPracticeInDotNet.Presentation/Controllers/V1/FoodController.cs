using BestPracticeInDotNet.Presentation.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestPracticeInDotNet.Presentation.Api.Controllers.V1;

[ApiVersion("1.0")]
[Authorize]
public class FoodController : ApiBase
{
    [HttpGet(ApiRoutes.Dinner.Get)]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}