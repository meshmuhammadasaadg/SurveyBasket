using System.Linq.Dynamic.Core;

namespace SurveyBasket.Api.Abstractions;

public static class IQueryableExtensions
{
    public static IQueryable<T> SortingBy<T>(this IQueryable<T> query, string? sortColumn, string? sortDirection)
    {
        if (string.IsNullOrEmpty(sortColumn))
            return query;

        var property = typeof(T).GetProperty(
            sortColumn,
            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance
            );

        if (property is null)
            return query;

        if (string.IsNullOrWhiteSpace(sortDirection))
            return query;

        var direction = sortDirection.Trim().ToLower();

        if (direction is not ("asc" or "ascending" or "desc" or "descending"))
            return query;

        return query.OrderBy($"{property.Name} {direction}");
    }
}
