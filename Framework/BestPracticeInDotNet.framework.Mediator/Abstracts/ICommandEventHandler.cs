using MediatR;

namespace Mc2.CrudTest.framework.Mediator.Abstracts;

public interface ICommandEventHandler<in TCommand> : INotificationHandler<TCommand>
    where TCommand : INotification
{
    
}