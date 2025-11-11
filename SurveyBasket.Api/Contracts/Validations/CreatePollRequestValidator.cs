using FluentValidation;
using SurveyBasket.Api.Contracts.Requests;

namespace SurveyBasket.Api.Contracts.Validations;

public class CreatePollRequestValidator : AbstractValidator<CreatePollRequest>
{
    public CreatePollRequestValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty()
            .Length(3, 100);

        RuleFor(c => c.Description)
            .NotEmpty()
            .Length(3, 100);
    }
}
