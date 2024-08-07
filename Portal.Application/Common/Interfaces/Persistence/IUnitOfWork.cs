﻿namespace Portal.Application.Common.Interfaces.Persistence;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IEmployeeRepository EmployeeRepository { get; }
}
