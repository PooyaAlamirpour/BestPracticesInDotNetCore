using BestPracticeInDotNet.Domain.Core.DomainModels.Food.ValueObjects;
using BestPracticeInDotNet.Domain.Core.DomainModels.Host.ValueObjects;
using BestPracticeInDotNet.Domain.Core.DomainModels.Menu.Entities;
using BestPracticeInDotNet.Domain.Core.DomainModels.Menu.ValueObjects;
using BestPracticeInDotNet.Domain.Core.DomainModels.MenuReview.ValueObjects;
using BestPracticeInDotNet.framework.DDD;
using MediatR;

namespace BestPracticeInDotNet.Domain.Core.DomainModels.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get; }
    public HostId HostId { get; }

    private static readonly List<MenuSection> _sections = new();
    private static readonly List<FoodId> _foodIds = new();
    private static readonly List<MenuReviewId> _menuReviewIds = new();
    public IReadOnlyList<MenuSection> Sections = _sections.AsReadOnly();
    public IReadOnlyList<FoodId> FoodIds = _foodIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds = _menuReviewIds.AsReadOnly();

    private Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
    }

    public static Menu Create(string name, string description, HostId hostId)
    {
        return new Menu(MenuId.CreateUnique(), name, description, hostId);
    }

    public override void Apply(INotification @event)
    {
        throw new NotImplementedException();
    }
}