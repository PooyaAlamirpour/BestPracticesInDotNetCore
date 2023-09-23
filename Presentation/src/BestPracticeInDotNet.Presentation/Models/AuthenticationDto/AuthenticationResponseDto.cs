namespace BestPracticeInDotNet.Presentation.Server.Models.AuthenticationDto;

public record AuthenticationResponseDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);
    