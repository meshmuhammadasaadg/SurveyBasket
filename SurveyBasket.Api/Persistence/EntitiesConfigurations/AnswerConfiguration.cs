namespace SurveyBasket.Api.Persistence.EntitiesConfigurations;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.HasIndex(c => new { c.QuestionId, c.Content }).IsUnique();

        builder.Property(c => c.Content).HasMaxLength(1000);
    }
}
