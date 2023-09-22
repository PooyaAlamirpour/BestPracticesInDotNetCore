namespace BestPracticeInDotNet.Presentation.Contracts.Authentication;

public record LoginRequestDto(
    string Email,
    string Password);