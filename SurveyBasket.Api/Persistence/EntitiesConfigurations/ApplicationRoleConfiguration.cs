using SurveyBasket.Api.Abstractions.DataSeeding;

namespace SurveyBasket.Api.Persistence.EntitiesConfigurations;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        var adminRole = new ApplicationRole
        {
            Id = DefaultRoles.Admin.Id,
            Name = DefaultRoles.Admin.Name,
            NormalizedName = DefaultRoles.Admin.NormalizedName,
            ConcurrencyStamp = DefaultRoles.Admin.ConcurrencyStamp,
        };

        var memberRole = new ApplicationRole
        {
            Id = DefaultRoles.Member.Id,
            Name = DefaultRoles.Member.Name,
            NormalizedName = DefaultRoles.Member.NormalizedName,
            ConcurrencyStamp = DefaultRoles.Member.ConcurrencyStamp,
            IsDefault = true
        };

        builder.HasData(adminRole, memberRole);
    }
}
