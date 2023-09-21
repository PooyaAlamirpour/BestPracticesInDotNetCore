using BestPracticeInDotNet.Domain.Core.User;

namespace BestPracticeInDotNet.Application.Queries.Repositories;

public interface IUserReadRepository : IGenericReadRepository<User, Guid>
{
    Task<User?> GetByEmailAsync(string email);
}