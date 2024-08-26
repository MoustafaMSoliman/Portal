using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.Entities.Employee.ValueObjects;
using Portal.Domain.User.ValueObjects;

namespace Portal.Infrastructure.Configuration.UserConfiguration.EmployeeConfiguration;

public class VacationConfig : IEntityTypeConfiguration<Vacation>
{
    public void Configure(EntityTypeBuilder<Vacation> builder)
    {
        builder.ToTable("Vacations");
        builder.HasKey(x=> x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => VacationId.Create(value))
            ;
        builder.Property(x=>x.EmployeeId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => UserId.Create(value))
            ;
        builder.HasOne(x => x.Employee)
            .WithMany(y => y.Vacations)
            .HasForeignKey(x => x.EmployeeId);
        builder.Property(x => x.AcceptedBy)
            .HasColumnName("AcceptedBy")
            .HasConversion(x=>x.Value, value=>UserId.Create(value));
        builder.Property(x => x.RejectedBy)
            .HasColumnName("RejectedBy")
            .HasConversion(x => x.Value, value => UserId.Create(value));
        builder.Property(x => x.ApprovedBy)
            .HasColumnName("ApprovedBy")
            .HasConversion(x => x.Value, value => UserId.Create(value));
        //builder.HasOne(x => x.AcceptedBy)
        //    .WithOne()
        //    .HasForeignKey<Vacation>(x => x.AcceptedBy);
        //builder.HasOne(x => x.RejectedBy)
        //    .WithOne()
        //    .HasForeignKey<Vacation>(x => x.RejectedBy);
        //builder.HasOne(x => x.ApprovedBy)
        //    .WithOne()
        //    .HasForeignKey<Vacation>(x => x.ApprovedBy);

    }
}
