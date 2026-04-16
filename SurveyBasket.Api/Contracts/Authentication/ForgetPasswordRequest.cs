namespace SurveyBasket.Api.Contracts.Authentication;

public record ForgetPasswordRequest(string Email);

public class ForgetPasswordRequestValidator : AbstractValidator<ForgetPasswordRequest>
{
    public ForgetPasswordRequestValidator()
    {
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
    }
}
