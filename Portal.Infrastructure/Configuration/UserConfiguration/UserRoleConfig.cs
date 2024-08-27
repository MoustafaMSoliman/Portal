using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.User.ValueObjects;

namespace Portal.Infrastructure.Configuration.UserConfiguration;

public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles");
        builder.HasKey(x=> x.Id);   
        builder.Ignore(x => x.Value);
        builder.Property(x=>x.RoleName).IsRequired().HasColumnName("Role");
    }
}
