namespace SurveyBasket.Api.Errors;

public static class VoteErrors
{
    public static readonly Error VoteNotFound =
        new("Vote.NotFound", "No Vote was found with the given ID", StatusCodes.Status404NotFound);

    public static readonly Error DuplicatedVote =
        new("Vote.DuplicatedVote", "cannot the same user towis voted on the same poll", StatusCodes.Status409Conflict);

    public static readonly Error InvalidQuestions =
        new("Vote.InvalidQuestions", "Invalid questions with the given ID", StatusCodes.Status404NotFound);
}
