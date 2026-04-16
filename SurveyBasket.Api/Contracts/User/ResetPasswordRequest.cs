namespace SurveyBasket.Api.Contracts.User;

public record ResetPasswordRequest(string Email, string Code, string NewPassword);

public class ResetPasswordRequestValidator : AbstractValidator<ResetPasswordRequest>
{
    public ResetPasswordRequestValidator()
    {
        RuleFor(c => c.Email)
           .NotEmpty()
           .EmailAddress();

        RuleFor(c => c.Code)
           .NotEmpty();

        RuleFor(c => c.NewPassword)
            .NotEmpty()
            .Matches(RegexPattern.Password)
            .WithMessage("password should be at least 8 digits and contains upperCase, lowercase, NonAlphanumeric");

    }
}