namespace BestPracticeInDotNet.Presentation.Server.Commons.Models.AuthenticationDto;

public record RegisterRequestDto(
    string FirstName,
    string LastName,
    string Email,
    string Password);