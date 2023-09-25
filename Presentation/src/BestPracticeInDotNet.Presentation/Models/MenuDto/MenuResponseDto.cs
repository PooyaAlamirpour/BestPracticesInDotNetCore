namespace BestPracticeInDotNet.Presentation.Api.Models.MenuDto;

public record MenuResponseDto(
    Guid Id, 
    string Name, 
    string Description, 
    float? AverageRating,
    List<MenuSectionResponseDto> Sections,
    string HostId,
    List<string> FoodIds,
    List<string> MenuReviewIds,
    DateTime CreatedAt,
    DateTime ModifiedAt);
