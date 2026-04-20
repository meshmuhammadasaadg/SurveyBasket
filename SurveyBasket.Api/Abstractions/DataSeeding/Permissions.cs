namespace SurveyBasket.Api.Abstractions.DataSeeding;

public static class Permissions
{
    public static string Type { get; } = "permissions";

    // Polls
    public const string GetPolls = "polls:read";
    public const string AddPolls = "polls:Create";
    public const string DeletePolls = "polls:Delete";
    public const string UpdatePolls = "polls:Edit";

    // Questions
    public const string GetQuestions = "questions:read";
    public const string AddQuestions = "questions:Create";
    public const string UpdateQuestions = "questions:Edit";

    // Users
    public const string GetUsers = "users:read";
    public const string AddUsers = "users:Create";
    public const string UpdateUsers = "users:Edit";

    // Roles
    public const string GetRoles = "roles:read";
    public const string AddRoles = "roles:Create";
    public const string UpdateRoles = "roles:Edit";

    // Results
    public const string Results = "results:read";

    public static IList<string?> GetAllPermissions() =>
         typeof(Permissions).GetFields().Select(c => c.GetValue(c) as string).ToList();
}
