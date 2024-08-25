using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Infrastructure.Configuration.UserConfiguration;

public class AttendanceConfig : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> att)
    {
        att.ToTable("Attendances");
        att.HasKey(x => x.Id);
        att.Property(x => x.EmployeeId)
        .HasConversion(id => id.Value, value => UserId.Create(value))
        .ValueGeneratedNever()
        .IsRequired();
        att.HasOne(x => x.Employee)
             .WithMany(y => y.Attendances)
             .HasForeignKey(x => x.EmployeeId);
        
    }
}
