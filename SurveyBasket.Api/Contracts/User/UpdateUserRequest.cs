namespace SurveyBasket.Api.Contracts.User;

public record UpdateUserRequest(
    string FirstName,
    string LastName,
    string Email,
    IList<string> Roles
);

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().Length(3, 100);

        RuleFor(c => c.LastName).NotEmpty().Length(3, 100);

        RuleFor(c => c.Email).NotEmpty().EmailAddress();

        RuleFor(c => c.Roles)
            .Must(c => c.Distinct().Count() == c.Count)
            .WithMessage("you cannot add duplicated permissions for the same role")
            .When(c => c.Roles != null);
    }
}