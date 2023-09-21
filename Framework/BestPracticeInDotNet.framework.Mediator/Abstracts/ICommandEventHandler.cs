using MediatR;

namespace BestPracticeInDotNet.framework.Mediator.Abstracts;

public interface ICommandEventHandler<in TCommand> : INotificationHandler<TCommand>
    where TCommand : INotification
{
    
}