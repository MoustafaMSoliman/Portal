using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.User.ValueObjects;

namespace Portal.Infrastructure.Configuration.UserConfiguration;

public class ProfileConfig : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable("Profiles");
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Nationality, nav => {
            nav.ToTable("Nations");
            nav.HasKey(x => x.Id);
            nav.Property(x => x.Name).HasColumnName("NationName");
        });
        builder.OwnsOne(x=>x.Address, add => {
            add.ToTable("Addresses");
            //add.HasKey("Id");
        });
           
    }
}
