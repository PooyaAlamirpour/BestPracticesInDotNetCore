namespace BestPracticeInDotNet.Infrastructure.Authentication.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string firstName, string lastName);
}