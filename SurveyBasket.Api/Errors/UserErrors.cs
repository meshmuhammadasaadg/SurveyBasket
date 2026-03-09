
namespace SurveyBasket.Api.Errors;

public static class UserErrors
{
    public static readonly Error InvalidCredentials =
        new("User.InvaildCredintials", "Invaild Email/Password", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidToken =
    new("Token.InvalidToken", "InvalidToken", StatusCodes.Status401Unauthorized);
}
