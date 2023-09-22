namespace BestPracticeInDotNet.Presentation.Server.Commons.Models.AuthenticationDto;

public record LoginRequestDto(
    string Email,
    string Password);