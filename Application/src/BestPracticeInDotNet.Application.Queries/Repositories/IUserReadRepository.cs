namespace BestPracticeInDotNet.Application.Queries.Repositories;

public interface IUserReadRepository : IGenericReadRepository<Domain.Core.DomainModels.User.User, Guid>
{
    Task<Domain.Core.DomainModels.User.User?> GetByEmailAsync(string email);
}