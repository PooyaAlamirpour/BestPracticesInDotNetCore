using BestPracticeInDotNet.framework.DDD;
using BestPracticeInDotNet.framework.Mediator.Abstracts;

namespace BestPracticeInDotNet.Domain.Core.User;

public class User : AggregateRoot<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    
    public override void Apply(IDomainEvent @event)
    {
        throw new NotImplementedException();
    }
}