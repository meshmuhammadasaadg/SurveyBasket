namespace SurveyBasket.Api.Abstractions.DataSeeding;

public static class DefaultRoles
{
    public partial class Admin
    {
        public const string Id = "D6951876-E125-4896-A4A6-D2C31B89CBC0";
        public const string Name = "Admin";
        public const string NormalizedName = "ADMIN";
        public const string ConcurrencyStamp = "D6951876-E125-4896-A4A6-D2C31B89CBC0";
    }

    public partial class Member
    {
        public const string Id = "F7A1234B-C456-7890-D123-E45F67890ABC";
        public const string Name = "Member";
        public const string NormalizedName = "MEMBER";
        public const string ConcurrencyStamp = "F7A1234B-C456-7890-D123-E45F67890ABC";
    }

}
