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
        var users = _unitOfWork.UsersRepository.GetAll().ToList();
        return new RetrieveAllUsersResult(users);
    }
}
