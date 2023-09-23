namespace BestPracticeInDotNet.Presentation.Server.Models.AuthenticationDto;

public record RegisterRequestDto(
    string FirstName,
    string LastName,
    string Email,
    string Password);