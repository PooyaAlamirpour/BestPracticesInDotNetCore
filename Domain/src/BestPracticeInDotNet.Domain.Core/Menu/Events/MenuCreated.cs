using BestPracticeInDotNet.framework.DDD.Abstracts;

namespace BestPracticeInDotNet.Domain.Core.Menu.Events;

public record MenuCreated(Menu Menu) : IDomainEvent;