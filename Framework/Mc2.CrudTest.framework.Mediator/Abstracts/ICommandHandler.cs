using MediatR;

namespace Mc2.CrudTest.framework.Mediator.Abstracts;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : IRequest
{
    
}