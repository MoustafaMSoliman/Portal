using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Common.Enums;
using Portal.Domain.User;
using Portal.Domain.User.ValueObjects;

namespace Portal.Infrastructure.Configuration.UserConfiguration;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUserTable(builder);
        
    }
    private void ConfigureUserTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Id)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .ValueGeneratedNever();

        builder.HasOne(u=>u.Profile)
            .WithOne(p=>p.User)
            .HasForeignKey<User>(u=>u.ProfileId)
            .IsRequired(true);

        

       

        

        

        builder.Property(x => x.CreatedBy)
            .HasConversion(id => id.Value, value => UserId.Create(value));
        builder.Property(x => x.UpdatedBy)
            .HasConversion(id => id.Value, value => UserId.Create(value));


    }
    
}
