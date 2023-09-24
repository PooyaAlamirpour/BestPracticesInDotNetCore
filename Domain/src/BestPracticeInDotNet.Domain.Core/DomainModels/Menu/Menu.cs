using BestPracticeInDotNet.Domain.Core.DomainModels.Menu.Entities;
using BestPracticeInDotNet.Domain.Core.DomainModels.Menu.ValueObjects;
using BestPracticeInDotNet.framework.DDD;
using MediatR;

namespace BestPracticeInDotNet.Domain.Core.DomainModels.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }
    private readonly List<MenuSection> _menuSections = new();

    public Menu(MenuId id) : base(id)
    {
    }

    public override void Apply(INotification @event)
    {
        throw new NotImplementedException();
    }
}