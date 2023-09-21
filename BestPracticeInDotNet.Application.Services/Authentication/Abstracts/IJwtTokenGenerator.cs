namespace BestPracticeInDotNet.Application.Services.Authentication.Abstracts;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string firstName, string lastName);
}