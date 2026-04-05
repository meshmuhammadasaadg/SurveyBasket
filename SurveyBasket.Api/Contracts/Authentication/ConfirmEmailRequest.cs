namespace SurveyBasket.Api.Contracts.Authentication;

public record ConfirmEmailRequest(
    string UserId,
    string Code);


public class ConfirmEmailRequestValidator : AbstractValidator<ConfirmEmailRequest>
{
    public ConfirmEmailRequestValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Code).NotEmpty();
    }
}

public record ResendConfirmationEmailRequest(string Email);

public class ResendConfirmEmailRequestValidator : AbstractValidator<ResendConfirmationEmailRequest>
{
    public ResendConfirmEmailRequestValidator()
    {
        RuleFor(c => c.Email).NotEmpty();

    }
}