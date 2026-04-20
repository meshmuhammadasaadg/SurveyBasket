using SurveyBasket.Api.Abstractions.DataSeeding.Roles;
using SurveyBasket.Api.Abstractions.DataSeeding.Users;

namespace SurveyBasket.Api.Persistence.EntitiesConfigurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        var adminUserRole = new IdentityUserRole<string>
        {
            UserId = AdminUser.Id,
            RoleId = AdminRole.Id
        };

        builder.HasData(adminUserRole);
    }
}
