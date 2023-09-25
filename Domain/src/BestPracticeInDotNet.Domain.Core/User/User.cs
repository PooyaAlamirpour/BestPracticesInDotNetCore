using BestPracticeInDotNet.framework.DDD;
using MediatR;

namespace BestPracticeInDotNet.Domain.Core.User;

public class User : AggregateRoot<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    
    public User(Guid id) : base(id)
    {
    }
    
    public override void Apply(INotification @event)
    {
        throw new NotImplementedException();
    }
}