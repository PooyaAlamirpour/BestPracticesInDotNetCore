using BestPracticeInDotNet.Application.Queries.Repositories;
using BestPracticeInDotNet.Domain.Core.User;

namespace BestPracticeInDotNet.Infrastructure.Persistence.Repositories;

public class UserReadRepository : GenericReadRepository<User, Guid>, IUserReadRepository
{
    public UserReadRepository(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}