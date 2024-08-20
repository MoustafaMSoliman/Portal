using Microsoft.EntityFrameworkCore;
using Portal.Domain.Common.Enums;
using Portal.Domain.Department;
using Portal.Domain.User;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;
using Department = Portal.Domain.Department.Department;

namespace Portal.Infrastructure.Persistence;

public class PortalDbContext : DbContext
{
    public DbSet<User> Users { get; set; } 
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Manager> Managers { get; set; } 
    public DbSet<Department> Departments { get; set; }
    public DbSet<Attendance> Attendances { get; set; } 
    public DbSet<Vacation> Vacations { get; set; } 
    public DbSet<Claim> Claims { get; set; } 

    public PortalDbContext(DbContextOptions<PortalDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
        
    }
}
