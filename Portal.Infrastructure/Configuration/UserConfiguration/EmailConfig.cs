using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.User.ValueObjects;

namespace Portal.Infrastructure.Configuration.UserConfiguration;

public class EmailConfig : IEntityTypeConfiguration<Email>
{
    public void Configure(EntityTypeBuilder<Email> emailEntityTypeBuilder)
    {
        emailEntityTypeBuilder.ToTable("Emails");
        emailEntityTypeBuilder.HasKey(x => x.Id);

    }
}
