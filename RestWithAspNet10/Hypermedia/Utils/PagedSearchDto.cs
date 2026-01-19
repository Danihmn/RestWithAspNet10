using RestWithAspNet10.Hypermedia.Abstract;

namespace RestWithAspNet10.Hypermedia.Utils;

public class PagedSearchDto<T> where T : ISupportHypermedia
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalResults { get; set; }
    public List<T> List { get; set; } = [];
    public string? SortFields { get; set; }
    public string? SortDirections { get; set; }
    public Dictionary<string, object> Filters { get; set; }

    public PagedSearchDto
    (
        int currentPage,
        int pageSize,
        string? sortFields,
        string? sortDirections,
        Dictionary<string, object> filters
    )
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        SortFields = sortFields;
        SortDirections = sortDirections;
        Filters = filters ?? [];
    }

    // Calls the first constructor with default parameters
    public PagedSearchDto
    (
        int currentPage,
        string? sortFields,
        string? sortDirections
    ) : this(currentPage, 10, sortFields, sortDirections, null)
    {
    }

    public int GetCurrentPage() => CurrentPage == 0 ? 1 : CurrentPage;

    public int GetPageSize() => PageSize == 0 ? 10 : PageSize;
}