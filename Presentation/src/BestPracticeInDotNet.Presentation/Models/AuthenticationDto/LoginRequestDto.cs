namespace BestPracticeInDotNet.Presentation.Server.Models.AuthenticationDto;

public record LoginRequestDto(
    string Email,
    string Password);