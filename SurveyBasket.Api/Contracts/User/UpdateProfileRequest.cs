namespace SurveyBasket.Api.Contracts.User;

public record UpdateProfileRequest(string FirstName, string LastName);

public class UpdateProfileRequestValidator : AbstractValidator<UpdateProfileRequest>
{
    public UpdateProfileRequestValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().Length(3, 100);

        RuleFor(c => c.LastName).NotEmpty().Length(3, 100);
    }
}