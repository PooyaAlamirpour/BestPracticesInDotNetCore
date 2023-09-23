namespace BestPracticeInDotNet.Presentation.Api.Models.AuthenticationDto;

public record LoginRequestDto(
    string Email,
    string Password);