
using SurveyBasket.Api.Abstractions.DataSeeding;

namespace SurveyBasket.Api.Persistence.EntitiesConfigurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var adminUser = new ApplicationUser
        {
            Id = DefaultUsers.Admin.Id,
            FirstName = DefaultUsers.Admin.FirstName,
            LastName = DefaultUsers.Admin.LastName,
            UserName = DefaultUsers.Admin.Email,
            NormalizedUserName = DefaultUsers.Admin.Email.ToUpper(),
            Email = DefaultUsers.Admin.Email,
            NormalizedEmail = DefaultUsers.Admin.Email.ToUpper(),
            EmailConfirmed = true,
            SecurityStamp = DefaultUsers.Admin.SecurityStamp,
            ConcurrencyStamp = DefaultUsers.Admin.ConcurrencyStamp,
            PasswordHash = DefaultUsers.Admin.PasswordHash,
        };

        builder.HasData(adminUser);

        builder
            .OwnsMany(x => x.RefreshTokens)
            .ToTable("RefreshTokens")
            .WithOwner()
            .HasForeignKey("UserId");

        builder.Property(u => u.FirstName).HasMaxLength(100);
        builder.Property(u => u.LastName).HasMaxLength(100);
    }
}
