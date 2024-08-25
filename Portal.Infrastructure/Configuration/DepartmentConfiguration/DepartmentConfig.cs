using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Department;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;
using System.Reflection.Emit;

namespace Portal.Infrastructure.Configuration.DepartmentConfiguration;

public class DepartmentConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");
        builder.HasKey(x=>x.Id);
        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => DepartmentId.Create(value))
            .ValueGeneratedNever()
           .IsRequired();

    }
}
