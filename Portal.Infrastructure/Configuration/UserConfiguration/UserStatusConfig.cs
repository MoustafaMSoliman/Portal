using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.User.ValueObjects;

namespace Portal.Infrastructure.Configuration.UserConfiguration;

public class UserStatusConfig : IEntityTypeConfiguration<UserStatus>
{
    public void Configure(EntityTypeBuilder<UserStatus> builder)
    {
        builder.ToTable("UserStatuses");
        builder.HasKey(x => x.Id);
        builder.Ignore(x => x.Value);
        builder.Property(x => x.StatusName).IsRequired().HasColumnName("Status");
    }
}
