namespace SurveyBasket.Api.Entities;

public sealed class AppUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public IList<RefreshToken> RefreshTokens { get; set; } = [];
}
