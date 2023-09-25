namespace BestPracticeInDotNet.Application.Queries.Repositories;

public interface IUserReadRepository : IGenericReadRepository<Domain.Core.User.User, Guid>
{
    Task<Domain.Core.User.User?> GetByEmailAsync(string email);
}