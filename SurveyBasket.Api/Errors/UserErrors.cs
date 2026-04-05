
namespace SurveyBasket.Api.Errors;

public static class UserErrors
{
    public static readonly Error InvalidCredentials =
        new("User.InvalidCredentials", "Invalid Email/Password", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidToken =
    new("Token.InvalidToken", "Invalid jwt Token", StatusCodes.Status401Unauthorized);

    public static readonly Error DuplicatedEmail =
    new("Email.DuplicatedEmail", "We find user use this Email, Enter another email Please.", StatusCodes.Status401Unauthorized);

    public static readonly Error EmailNotConfirmed =
    new("Email.EmailNotConfirmed", "Email is not confirmed.", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidCode =
    new("User.InvalidCode", "Invalid Code.", StatusCodes.Status401Unauthorized);

    public static readonly Error EmailIsConfirmed =
    new("Email.EmailIsConfirmed", "Email is already confirmed.", StatusCodes.Status401Unauthorized);
}
