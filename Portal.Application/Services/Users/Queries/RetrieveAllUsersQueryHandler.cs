using ErrorOr;
using MediatR;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Users.Common;
using Portal.Domain.Common.Errors;

namespace Portal.Application.Services.Users.Queries;

public class RetrieveAllUsersQueryHandler
    : IRequestHandler<RetrieveAllUsersQuery, ErrorOr<RetrieveAllUsersResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public RetrieveAllUsersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<RetrieveAllUsersResult>> Handle(RetrieveAllUsersQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var admin = _unitOfWork.AdministratorsRepository.GetById(query.AdminId);
        if (admin is null)
            return Errors.AdminsErrors.NotAdmin;
        var users = _unitOfWork.UsersRepository.GetAllWithInclude(x=>x.Profile,x=>x.Profile.Address).ToList();
        List<UserResult> userResults = new();
        foreach (var user in users) {
            userResults.Add(
                new UserResult(user.Code, user.Profile.FirstName, user.Profile.LastName )
                );
        }
        return new RetrieveAllUsersResult(userResults);
    }
}
