using MediatR;

namespace BestPracticeInDotNet.framework.Mediator.Abstracts;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : IRequest
{
    
}