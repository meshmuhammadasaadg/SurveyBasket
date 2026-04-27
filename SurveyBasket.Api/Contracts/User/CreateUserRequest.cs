namespace SurveyBasket.Api.Contracts.User;

public record CreateUserRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    IList<string> Roles
);

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().Length(3, 100);

        RuleFor(c => c.LastName).NotEmpty().Length(3, 100);

        RuleFor(c => c.Email).NotEmpty().EmailAddress();

        RuleFor(c => c.Password)
                 .NotEmpty()
                 .Matches(RegexPattern.Password)
                 .WithMessage("password should be at least 8 digits and contains upperCase, lowercase, NonAlphanumeric");


        RuleFor(c => c.Roles)
            .Must(c => c.Distinct().Count() == c.Count)
            .WithMessage("you cannot add duplicated permissions for the same role")
            .When(c => c.Roles != null);
    }
}