using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Department;
using Portal.Domain.User.ValueObjects;

namespace Portal.Infrastructure.Configuration.DepartmentConfiguration;

public class DepartmentConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");
        builder.HasKey(x=>x.Id);
        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .ValueGeneratedNever()
           .IsRequired();
    }
}
