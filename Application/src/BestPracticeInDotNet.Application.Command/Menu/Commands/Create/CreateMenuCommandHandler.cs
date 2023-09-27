using ErrorOr;
using MediatR;

namespace BestPracticeInDotNet.Application.Command.Menu.Commands.Create;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Domain.Core.Menu.Menu>>
{
    public Task<ErrorOr<Domain.Core.Menu.Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}