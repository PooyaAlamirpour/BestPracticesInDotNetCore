namespace BestPracticeInDotNet.Presentation.Api.Models.MenuDto;

public record CreateMenuRequestDto(
    string Name,
    string Description,
    List<MenuSectionDto> Sections);