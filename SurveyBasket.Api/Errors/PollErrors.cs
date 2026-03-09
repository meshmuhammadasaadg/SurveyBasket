namespace SurveyBasket.Api.Errors;

public static class PollErrors
{
    public static readonly Error PollNotFound =
        new("NotFound", "No poll was found with the given ID", StatusCodes.Status404NotFound);

    public static readonly Error ExistingTitle =
        new("Poll.DuplicatedTitle", "Cannot insert Duplicated title,We found poll with the same title", StatusCodes.Status409Conflict);
}
