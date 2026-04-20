
using SurveyBasket.Api.Abstractions.DataSeeding.Users;

namespace SurveyBasket.Api.Persistence.EntitiesConfigurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var adminUser = new ApplicationUser
        {
            Id = AdminUser.Id,
            FirstName = AdminUser.FirstName,
            LastName = AdminUser.LastName,
            UserName = AdminUser.Email,
            NormalizedUserName = AdminUser.Email.ToUpper(),
            Email = AdminUser.Email,
            NormalizedEmail = AdminUser.Email.ToUpper(),
            EmailConfirmed = true,
            SecurityStamp = AdminUser.SecurityStamp,
            ConcurrencyStamp = AdminUser.ConcurrencyStamp,
            PasswordHash = "AQAAAAIAAYagAAAAELTBMSaom3U7o1sXnbkVgZUYbwtWeZdqQOvpIP71BBpUK9J7wHhW7ZviRQbkmXKIOg=="
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
