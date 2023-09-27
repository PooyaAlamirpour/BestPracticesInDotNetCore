using BestPracticeInDotNet.Application.Command.Menu.Commands.Create;
using BestPracticeInDotNet.Presentation.Api.Models.MenuDto;
using Mapster;

namespace BestPracticeInDotNet.Presentation.Api.Mapping;

public class MenuMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequestDto request, string hostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.hostId)
            .Map(dest => dest, src => src.request);
    }
}