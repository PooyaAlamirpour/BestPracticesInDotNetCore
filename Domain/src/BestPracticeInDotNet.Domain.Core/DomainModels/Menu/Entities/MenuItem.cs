﻿using BestPracticeInDotNet.Domain.Core.DomainModels.Menu.ValueObjects;
using BestPracticeInDotNet.framework.DDD;

namespace BestPracticeInDotNet.Domain.Core.DomainModels.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; }
    public string Description { get; }
    
    private MenuItem(MenuItemId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }
}