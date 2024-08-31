using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Common.AccessContorl;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.ValueObjects;

namespace Portal.Infrastructure.Configuration.UserConfiguration.AdministratorConfiguration;

public class AdminDepartmentConfig : IEntityTypeConfiguration<AdministratorDepartment>
{
    public void Configure(EntityTypeBuilder<AdministratorDepartment> builder)
    {
        builder.ToTable("AdminsDepartments");
        builder.HasKey(e => new { e.DepartmentId,e.AdminId});
        builder.Property(x=>x.DepartmentId)
            .ValueGeneratedNever()
            .HasConversion(x=>x.Value, value=>DepartmentId.Create(value));
        builder.Property(x=>x.AdminId)
            .ValueGeneratedNever()
            .HasConversion(x=>x.Value,value=>UserId.Create(value));
        builder.HasOne(x => x.Administrator)
            .WithMany(x => x.AdministratorDepartments)
            .HasForeignKey(x => x.AdminId);
        builder.HasOne(x => x.Department)
            .WithMany(x => x.AdministratorDepartments)
            .HasForeignKey(x => x.DepartmentId);
    }
}
