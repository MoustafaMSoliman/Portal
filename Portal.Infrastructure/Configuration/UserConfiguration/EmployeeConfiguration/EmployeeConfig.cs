using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.Entities.Employee.ValueObjects;
using Portal.Domain.User.ValueObjects;

namespace Portal.Infrastructure.Configuration.UserConfiguration.EmployeeConfiguration;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees")
            .HasBaseType<User>();

        //builder.HasKey(x => x.Id);

        builder.Property(x => x.DepartmentId)
            .HasConversion(id => id.Value, value => DepartmentId.Create(value))
            .ValueGeneratedNever()
            .IsRequired();
        
        

        //builder.OwnsMany(x => x.Vacations, vac => {
        //    vac.ToTable("Vacations");
        //    vac.HasKey(x => x.Id);
        //    vac.Property(x=>x.Id)
        //       .HasConversion(id => id.Value, value => VacationId.Create(value))
        //       .ValueGeneratedNever()
        //       .IsRequired();
        //    vac.Property(x => x.EmployeeId)
        //       .HasConversion(id => id.Value, value => UserId.Create(value))
        //       .ValueGeneratedNever()
        //       .IsRequired();
        //    vac.WithOwner().HasForeignKey(x=>x.EmployeeId);
        //});

        builder.HasMany(x => x.Vacations)
            .WithOne(x => x.Employee)
            .HasForeignKey(x => x.EmployeeId)
            .HasPrincipalKey(x=>x.Id);

        builder.HasMany(x => x.Attendances)
             .WithOne(x => x.Employee)
             .HasForeignKey(x => x.EmployeeId)
             .HasPrincipalKey(x => x.Id);

        builder.HasOne(x => x.Department)
            .WithMany(x => x.Employees)
            ;

        //builder.OwnsOne(x=>x.CareerGroup, cg => {
        //    cg.ToTable("CareerGroups");
        //    cg.HasKey("Id");
        //    cg.OwnsMany(x=>x.Specializations, sp => {
        //        sp.ToTable("CareerSpecializations");
        //        sp.HasKey("Id");
        //        sp.OwnsMany(x=>x.CareerTitles, ct => {
        //            ct.ToTable("CareerTitles");
        //            ct.HasKey("Id");

        //        });
        //    });
        //});

    }
}
