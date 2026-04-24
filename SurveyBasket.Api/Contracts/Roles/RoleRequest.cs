namespace SurveyBasket.Api.Contracts.Roles;

public record RoleRequest(
    string Name,
    IList<string> Permissions
);

public class RoleRequestValidator : AbstractValidator<RoleRequest>
{
    public RoleRequestValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .Length(3, 100);

        RuleFor(c => c.Permissions)
            .NotNull()
            .NotEmpty();

        RuleFor(c => c.Permissions)
            .Must(c => c.Distinct().Count() == c.Count)
            .WithMessage("you cannot add duplicated permissions for the same role")
            .When(c => c.Permissions != null);

    }
}
