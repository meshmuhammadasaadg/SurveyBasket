namespace SurveyBasket.Api.Contracts.Common;

public record PageFilters
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string? SearchValue { get; init; }
    public string? SortColumn { get; init; }
    public string? SortDirection { get; init; } = "ASC";
};

public class PageFiltersValidator : AbstractValidator<PageFilters>
{
    public PageFiltersValidator()
    {
        RuleFor(c => c.PageSize)
            .LessThanOrEqualTo(50);

        RuleFor(c => c.PageNumber).GreaterThan(0);
    }
}