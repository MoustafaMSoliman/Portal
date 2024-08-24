﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Department;
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
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .ValueGeneratedNever()
           .IsRequired();
        

        //builder.HasOne(x => x.Secretery)
        //     .WithOne(x => x.Department)
        //     .HasForeignKey<Department>(x => x.SecreteryId)
        //.IsRequired();
        builder.Property(x => x.ManagerId)
       .HasConversion(id => id.Value, value => UserId.Create(value))
       .ValueGeneratedNever()
      .IsRequired();
        
        builder.HasMany(x => x.Employees)
            .WithOne(y => y.Department)
            .HasForeignKey(x => x.DepartmentId)
            .IsRequired(true)
            ;
        //builder.HasIndex(x => x.Employees)
        //    .IsUnique(false);

    }
}
