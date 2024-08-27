﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portal.Infrastructure.Persistence;

#nullable disable

namespace Portal.Infrastructure.Migrations
{
    [DbContext(typeof(PortalDbContext))]
    partial class PortalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Portal.Domain.Department.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId")
                        .IsUnique();

                    b.ToTable("Departments", (string)null);
                });

            modelBuilder.Entity("Portal.Domain.User.Entities.Employee.Entities.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ArrivedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("AttendaceStatus")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("CanSignOutAfter")
                        .HasColumnType("time");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("LateHours")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LeaveAt")
                        .HasColumnType("datetime2");

                    b.Property<TimeOnly>("MustSignInBefore")
                        .HasColumnType("time");

                    b.Property<int?>("OvertimeHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Attendances", (string)null);
                });

            modelBuilder.Entity("Portal.Domain.User.Entities.Employee.Entities.Claim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttendanceId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttendanceId")
                        .IsUnique();

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("Portal.Domain.User.Entities.Employee.Entities.Vacation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AcceptedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AcceptedBy");

                    b.Property<DateTime?>("AcceptedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ApprovedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ApprovedBy");

                    b.Property<DateTime?>("ApprovedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("RejectedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RejectedBy");

                    b.Property<DateTime?>("RejectedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartFrom")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalVacationDays")
                        .HasColumnType("int");

                    b.Property<int>("TotalVacationDaysEmergncy")
                        .HasColumnType("int");

                    b.Property<int>("TotalVacationDaysNormally")
                        .HasColumnType("int");

                    b.Property<int?>("VacationStatus")
                        .HasColumnType("int");

                    b.Property<int>("VacationType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Vacations", (string)null);
                });

            modelBuilder.Entity("Portal.Domain.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EmailId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserStatusId")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmailId")
                        .IsUnique();

                    b.HasIndex("ProfileId")
                        .IsUnique();

                    b.HasIndex("UserRoleId")
                        .IsUnique();

                    b.HasIndex("UserStatusId")
                        .IsUnique();

                    b.HasIndex("UserTypeId")
                        .IsUnique();

                    b.ToTable("Users", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Portal.Domain.User.ValueObjects.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Emails", (string)null);
                });

            modelBuilder.Entity("Portal.Domain.User.ValueObjects.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NationalId")
                        .HasColumnType("bigint");

                    b.Property<int>("NationalityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Profiles", (string)null);
                });

            modelBuilder.Entity("Portal.Domain.User.ValueObjects.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Role");

                    b.HasKey("Id");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Portal.Domain.User.ValueObjects.UserStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("UserStatuses", (string)null);
                });

            modelBuilder.Entity("Portal.Domain.User.ValueObjects.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.ToTable("UserTypes", (string)null);
                });

            modelBuilder.Entity("Portal.Domain.User.Entities.Employee.Employee", b =>
                {
                    b.HasBaseType("Portal.Domain.User.User");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("Portal.Domain.User.Entities.Employee.Entities.Manager", b =>
                {
                    b.HasBaseType("Portal.Domain.User.Entities.Employee.Employee");

                    b.Property<string>("Office")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Office");

                    b.ToTable("Managers", (string)null);
                });

            modelBuilder.Entity("Portal.Domain.Department.Department", b =>
                {
                    b.HasOne("Portal.Domain.User.Entities.Employee.Entities.Manager", "Manager")
                        .WithOne("Department")
                        .HasForeignKey("Portal.Domain.Department.Department", "ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Portal.Domain.User.Entities.Employee.Entities.Attendance", b =>
                {
                    b.HasOne("Portal.Domain.User.Entities.Employee.Employee", "Employee")
                        .WithMany("Attendances")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Portal.Domain.User.Entities.Employee.Entities.Claim", b =>
                {
                    b.HasOne("Portal.Domain.User.Entities.Employee.Entities.Attendance", null)
                        .WithOne("Claim")
                        .HasForeignKey("Portal.Domain.User.Entities.Employee.Entities.Claim", "AttendanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Domain.User.Entities.Employee.Entities.Vacation", b =>
                {
                    b.HasOne("Portal.Domain.User.Entities.Employee.Employee", "Employee")
                        .WithMany("Vacations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Portal.Domain.User.User", b =>
                {
                    b.HasOne("Portal.Domain.User.ValueObjects.Email", "Email")
                        .WithOne("User")
                        .HasForeignKey("Portal.Domain.User.User", "EmailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portal.Domain.User.ValueObjects.Profile", "Profile")
                        .WithOne("User")
                        .HasForeignKey("Portal.Domain.User.User", "ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portal.Domain.User.ValueObjects.UserRole", "UserRole")
                        .WithOne("User")
                        .HasForeignKey("Portal.Domain.User.User", "UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portal.Domain.User.ValueObjects.UserStatus", "UserStatus")
                        .WithOne("User")
                        .HasForeignKey("Portal.Domain.User.User", "UserStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portal.Domain.User.ValueObjects.UserType", "UserType")
                        .WithOne("User")
                        .HasForeignKey("Portal.Domain.User.User", "UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Email");

                    b.Navigation("Profile");

                    b.Navigation("UserRole");

                    b.Navigation("UserStatus");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("Portal.Domain.User.ValueObjects.Profile", b =>
                {
                    b.OwnsOne("Portal.Domain.User.ValueObjects.Nationality", "Nationality", b1 =>
                        {
                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("NationName");

                            b1.HasKey("Id");

                            b1.ToTable("Nations", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("Id");
                        });

                    b.OwnsOne("Portal.Domain.User.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("ProfileId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProfileId");

                            b1.ToTable("Addresses", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ProfileId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Nationality")
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Domain.User.Entities.Employee.Employee", b =>
                {
                    b.HasOne("Portal.Domain.Department.Department", null)
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portal.Domain.User.User", null)
                        .WithOne()
                        .HasForeignKey("Portal.Domain.User.Entities.Employee.Employee", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Domain.User.Entities.Employee.Entities.Manager", b =>
                {
                    b.HasOne("Portal.Domain.User.Entities.Employee.Employee", null)
                        .WithOne()
                        .HasForeignKey("Portal.Domain.User.Entities.Employee.Entities.Manager", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Domain.Department.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Portal.Domain.User.Entities.Employee.Entities.Attendance", b =>
                {
                    b.Navigation("Claim");
                });

            modelBuilder.Entity("Portal.Domain.User.ValueObjects.Email", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Domain.User.ValueObjects.Profile", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Domain.User.ValueObjects.UserRole", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Domain.User.ValueObjects.UserStatus", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Domain.User.ValueObjects.UserType", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Domain.User.Entities.Employee.Employee", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Vacations");
                });

            modelBuilder.Entity("Portal.Domain.User.Entities.Employee.Entities.Manager", b =>
                {
                    b.Navigation("Department")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
