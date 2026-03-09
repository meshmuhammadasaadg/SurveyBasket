namespace SurveyBasket.Api.Presistence.EntitiesConfigurations;

public class VoteAnswerConfiguration : IEntityTypeConfiguration<VoteAnswer>
{
    public void Configure(EntityTypeBuilder<VoteAnswer> builder)
    {
        builder.HasIndex(c => new { c.QuestionId, c.VoteId }).IsUnique(); 
    }
}
