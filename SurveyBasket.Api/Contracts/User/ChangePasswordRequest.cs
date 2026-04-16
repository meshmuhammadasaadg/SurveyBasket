namespace SurveyBasket.Api.Contracts.User;

public record ChangePasswordRequest(string CurrentPassword, string NewPassword);

public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordRequestValidator()
    {
        RuleFor(c => c.CurrentPassword)
          .NotEmpty();

        RuleFor(c => c.NewPassword)
          .NotEmpty()
          .Matches(RegexPattern.Password)
          .WithMessage("password should be at least 8 digits and contains upperCase, lowercase, NonAlphanumeric")
          .NotEqual(x => x.CurrentPassword)
          .WithMessage("New Password Cannot be same as the current password");
    }
}