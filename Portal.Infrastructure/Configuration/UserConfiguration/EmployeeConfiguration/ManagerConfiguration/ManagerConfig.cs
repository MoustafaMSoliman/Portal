using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.User.Entities.Employee.Entities;

namespace Portal.Infrastructure.Configuration.UserConfiguration.EmployeeConfiguration.ManagerConfiguration;

public class ManagerConfig : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder.ToTable("Managers");
        builder.Property(x => x.Office)
            .HasColumnName("Office");
        
       

    }
}
