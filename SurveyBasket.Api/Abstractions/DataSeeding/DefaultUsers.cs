namespace SurveyBasket.Api.Abstractions.DataSeeding;

public static class DefaultUsers
{
    public partial class Admin
    {
        public const string Id = "A1B2C3D4-E5F6-7890-ABCD-EF1234567890";
        public const string FirstName = "Muhammad";
        public const string LastName = "Asaad";
        public const string Email = "admin@surveybasket.com";
        public const string Password = "Admin@123";
        public const string PasswordHash = "AQAAAAIAAYagAAAAELTBMSaom3U7o1sXnbkVgZUYbwtWeZdqQOvpIP71BBpUK9J7wHhW7ZviRQbkmXKIOg==";
        public const string SecurityStamp = "A1B2C3D4-E5F6-7890-ABCD-EF1234567890";
        public const string ConcurrencyStamp = "A1B2C3D4E5F67890ABCDEF1234567890";
    }
}
