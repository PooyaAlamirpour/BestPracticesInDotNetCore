using BestPracticeInDotNet.Domain.Core.User;

namespace BestPracticeInDotNet.Application.Command.Repositories;

public interface IUserWriteRepository : IGenericWriteRepository<User, Guid>
{
    
}