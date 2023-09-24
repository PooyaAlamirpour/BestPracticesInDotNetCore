using BestPracticeInDotNet.Domain.Core.DomainModels.User;

namespace BestPracticeInDotNet.Application.Command.Repositories;

public interface IUserWriteRepository : IGenericWriteRepository<User, Guid>
{
    
}