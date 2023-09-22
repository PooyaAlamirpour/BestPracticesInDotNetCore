namespace BestPracticeInDotNet.Presentation.Contracts.Authentication;

public record RegisterRequestDto(
    string FirstName,
    string LastName,
    string Email,
    string Password);