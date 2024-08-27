using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.User.ValueObjects;

namespace Portal.Infrastructure.Configuration.UserConfiguration;

public class UserTypeConfig : IEntityTypeConfiguration<UserType>
{
    public void Configure(EntityTypeBuilder<UserType> builder)
    {
        builder.ToTable("UserTypes");
        builder.HasKey(x => x.Id);
        builder.Ignore(x => x.Value);
        builder.Property(x => x.TypeName).IsRequired().HasColumnName("Type");
    }
}
