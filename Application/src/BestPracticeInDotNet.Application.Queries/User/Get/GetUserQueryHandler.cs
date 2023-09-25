using BestPracticeInDotNet.Application.Queries.Repositories;
using BestPracticeInDotNet.Domain.SubDomain.Errors;
using ErrorOr;
using MediatR;

namespace BestPracticeInDotNet.Application.Queries.User.Get;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ErrorOr<Domain.Core.User.User>>
{
    private readonly IUserReadRepository _userReadRepository;

    public GetUserQueryHandler(IUserReadRepository userReadRepository)
    {
        _userReadRepository = userReadRepository;
    }

    public async Task<ErrorOr<Domain.Core.User.User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.GetByEmailAsync(request.Email);
        if (user is null) return Errors.User.NotFound(request.Email);

        return user;
    }
    
}