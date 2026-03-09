namespace SurveyBasket.Api.Errors;

public static class QuestionErrors
{
    public static readonly Error DuplicatedQuestion =
        new("Question.DuplicatedContent", "Cannot duplicated question Content for the same poll", StatusCodes.Status409Conflict);
    public static readonly Error QuestionNotFound =
        new("Question.NotFound", "No question was found with the given ID", StatusCodes.Status404NotFound);
}
