using ErrorOr;
using MediatR;

namespace BestPracticeInDotNet.Application.Command.Menu.Commands.Create;

public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Domain.Core.Menu.Menu>>;
    
public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items);

public record MenuItemCommand(
    string Name,
    string Description);