namespace SurveyBasket.Api.Errors;

public static class QuestionErrors
{
    public static readonly Error DuplicatedQuestion =
        new("Question.DuplicatedContent", "Cannot duplicated question Content for the same poll");
    public static readonly Error QuestionNotFound =
        new("Question.NotFound", "No question was found with the given ID");
}
