using BestPracticeInDotNet.Application.Queries.Repositories;
using BestPracticeInDotNet.Domain.Core.DomainModels.User;

namespace BestPracticeInDotNet.Infrastructure.Persistence.Repositories;

public class UserReadRepository : GenericReadRepository<User, Guid>, IUserReadRepository
{
    public UserReadRepository(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return QueryableFilter(x => x.Email == email)?
            .FirstOrDefault();
    }
}