using BestPracticeInDotNet.Application.Command.Menu.Commands.Create;
using BestPracticeInDotNet.Presentation.Api.Controllers.Base;
using BestPracticeInDotNet.Presentation.Api.Models.MenuDto;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BestPracticeInDotNet.Presentation.Api.Controllers.V1;

[ApiVersion("1.0")]
public class MenusController : ApiBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public MenusController(IMapper mapper, ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    [HttpPost(ApiRoutes.Menu.Create)]
    public async Task<IActionResult> CreateMenu(CreateMenuRequestDto request, string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));
        var createMenuResponse = await _sender.Send(command);
        return Ok(request);
    }
}