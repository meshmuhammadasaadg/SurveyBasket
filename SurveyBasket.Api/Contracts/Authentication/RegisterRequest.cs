using SurveyBasket.Api.Abstractions.Constants;

namespace SurveyBasket.Api.Contracts.Authentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Password,
    string Email);

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(c => c.Email).NotEmpty().EmailAddress();

        RuleFor(c => c.Password)
            .NotEmpty()
            .Matches(RegexPattern.Password)
            .WithMessage("password should be at least 8 digits and contains upperCase, lowercase, NonAlphanumeric");

        RuleFor(c => c.FirstName).NotEmpty().Length(3, 100);

        RuleFor(c => c.LastName).NotEmpty().Length(3, 100);
    }
}