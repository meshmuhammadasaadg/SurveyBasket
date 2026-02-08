using FluentValidation;

namespace SurveyBasket.Api.Contracts.Authentication;

public record RefreshTokenRequest(
    string Token,
    string RefreshToken
);

public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidator()
    {
        RuleFor(c => c.Token).NotEmpty();
        RuleFor(c => c.RefreshToken).NotEmpty();
    }
}
