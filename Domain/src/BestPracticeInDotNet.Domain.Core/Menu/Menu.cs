using BestPracticeInDotNet.Domain.Core.Food.ValueObjects;
using BestPracticeInDotNet.Domain.Core.Host.ValueObjects;
using BestPracticeInDotNet.Domain.Core.Menu.Entities;
using BestPracticeInDotNet.Domain.Core.Menu.Events;
using BestPracticeInDotNet.Domain.Core.Menu.ValueObjects;
using BestPracticeInDotNet.Domain.Core.MenuReview.ValueObjects;
using BestPracticeInDotNet.framework.DDD;
using MediatR;

namespace BestPracticeInDotNet.Domain.Core.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<FoodId> _foodIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    
    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get; }
    public HostId HostId { get; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<FoodId> FoodIds => _foodIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    private Menu(MenuId id, 
        string name,
        string description,
        HostId hostId) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
    }

    public static Menu Create(string name, string description, HostId hostId)
    {
        var menu = new Menu(MenuId.CreateUnique(), name, description, hostId);
        menu.RaiseEvent(new MenuCreated(menu));
        return menu;
    }

    public override void Apply(INotification @event)
    {
        throw new NotImplementedException();
    }
    
    #pragma warning disable CS8618
    
    #pragma warning restore CS8618
}