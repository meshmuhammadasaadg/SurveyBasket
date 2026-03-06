namespace SurveyBasket.Api.Presistence.EntitiesConfigurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasIndex(c => new { c.PollId, c.Content }).IsUnique();

        builder.Property(c => c.Content).HasMaxLength(1000);
    }
}
