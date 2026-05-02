namespace SurveyBasket.Api.Errors;

public record RoleErrors
{
    public static readonly Error NotFound =
    new("Role.NotFound", "Role is not found", StatusCodes.Status404NotFound);

    public static readonly Error DuplicatedRole =
    new("Role.DuplicatedRole", "Another role have the same name you entered", StatusCodes.Status409Conflict);

    public static readonly Error InvalidPermissions =
    new("Role.InvalidPermissions", "Invalid Permissions", StatusCodes.Status400BadRequest);
}
