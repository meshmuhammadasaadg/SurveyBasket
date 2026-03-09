namespace SurveyBasket.Api.Presistence.EntitiesConfigurations;

public class VoteConfiguration : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.HasIndex(c => new { c.PollId, c.UserId }).IsUnique();
    }
}
