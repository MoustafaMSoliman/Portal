using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Infrastructure.Configuration.UserConfiguration.EmployeeConfiguration.ManagerConfiguration;

public class ManagerConfig : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder.ToTable("Managers")
            .HasBaseType<Employee>();
        //builder.HasKey(x => x.Id);

        //builder.Property(x => x.Id)
        //    .HasConversion(id => id.Value, value => UserId.Create(value))
        //    .ValueGeneratedNever()
        //    .IsRequired();
        
    }
}
