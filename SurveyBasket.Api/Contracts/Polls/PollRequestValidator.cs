using FluentValidation;

namespace SurveyBasket.Api.Contracts.Polls;

public class PollRequestValidator : AbstractValidator<PollRequest>
{
    public PollRequestValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty()
            .Length(3, 100);

        RuleFor(c => c.Summary)
            .NotEmpty()
            .Length(3, 1500);

        RuleFor(c => c.StartsAt)
            .NotEmpty()
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));

        RuleFor(c => c.EndsAt)
            .NotEmpty()
            //.Must()
            .GreaterThanOrEqualTo(c => c.StartsAt);
    }
}
