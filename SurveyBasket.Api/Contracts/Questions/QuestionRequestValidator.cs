using FluentValidation;

namespace SurveyBasket.Api.Contracts.Questions;

public class QuestionRequestValidator : AbstractValidator<QuestionRequest>
{
    public QuestionRequestValidator()
    {
        RuleFor(c => c.Content)
            .NotEmpty()
            .Length(3, 1000);

        RuleFor(c => c.Answers)
            .NotNull();

        RuleFor(c => c.Answers)
            .Must(x => x.Count > 1)
            .WithMessage("Question should has  at least 2 answers")
            .When(c => c.Answers != null);

        RuleFor(c => c.Answers)
            .Must(x => x.Distinct().Count() == x.Count)
            .WithMessage("You cannot add duplicated answers for the same question")
            .When(c => c.Answers != null);
    }
}
