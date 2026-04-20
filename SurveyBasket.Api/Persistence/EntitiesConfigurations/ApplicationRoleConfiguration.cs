using SurveyBasket.Api.Abstractions.DataSeeding.Roles;

namespace SurveyBasket.Api.Persistence.EntitiesConfigurations;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        var adminRole = new ApplicationRole
        {
            Id = AdminRole.Id,
            Name = AdminRole.Name,
            NormalizedName = AdminRole.NormalizedName,
            ConcurrencyStamp = AdminRole.ConcurrencyStamp,
        };

        var memberRole = new ApplicationRole
        {
            Id = MemberRole.Id,
            Name = MemberRole.Name,
            NormalizedName = MemberRole.NormalizedName,
            ConcurrencyStamp = MemberRole.ConcurrencyStamp,
            IsDefault = true
        };

        builder.HasData(adminRole, memberRole);
    }
}
