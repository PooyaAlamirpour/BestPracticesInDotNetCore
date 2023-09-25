using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Domain.Core.User;

namespace BestPracticeInDotNet.Infrastructure.Write.Persistence.Repository;

public class UserWriteRepository : GenericWriteRepository<User, Guid>, IUserWriteRepository
{
    public UserWriteRepository(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}