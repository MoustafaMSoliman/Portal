using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Common.Enums;
using Portal.Domain.Department;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.Entities.Employee.ValueObjects;
using Portal.Domain.User.ValueObjects;
using System.Reflection.Emit;

namespace Portal.Infrastructure.Configuration.UserConfiguration.EmployeeConfiguration;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees")
            .HasBaseType<User>();


        builder.HasMany(x => x.Vacations)
            .WithOne(x => x.Employee)
            .HasForeignKey(x => x.EmployeeId)
            .HasPrincipalKey(x=>x.Id);

        builder.HasMany(x => x.Attendances)
             .WithOne(x => x.Employee)
             .HasForeignKey(x => x.EmployeeId)
             .HasPrincipalKey(x => x.Id);
        
        

        
    }
}
