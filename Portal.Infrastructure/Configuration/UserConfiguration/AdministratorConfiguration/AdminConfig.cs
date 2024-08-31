using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.User;
using Portal.Domain.User.Entities.Administrator;

namespace Portal.Infrastructure.Configuration.UserConfiguration.AdministratorConfiguration;

public class AdminConfig : IEntityTypeConfiguration<Administrator>
{
    public void Configure(EntityTypeBuilder<Administrator> builder)
    {
        builder.ToTable("Administrators");
        builder.HasBaseType<User>();
    }
}
