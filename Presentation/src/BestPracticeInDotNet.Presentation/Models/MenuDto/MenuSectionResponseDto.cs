namespace BestPracticeInDotNet.Presentation.Api.Models.MenuDto;

public record MenuSectionResponseDto(
    string Id,
    string Name,
    string Description,
    List<MenuItemResponseDto> Items);
