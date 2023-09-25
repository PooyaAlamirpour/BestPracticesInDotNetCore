namespace BestPracticeInDotNet.Presentation.Api.Models.MenuDto;

public record MenuSectionDto(string Name, string Description, List<MenuItemDto> Items);
