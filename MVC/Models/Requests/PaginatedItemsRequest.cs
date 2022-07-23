namespace MVC.Dtos;

public class PaginatedItemsRequest<TFilter, TSorting>
    where TFilter : notnull
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public Dictionary<TFilter, int>? Filters { get; set; }

    public TSorting? Sorting { get; set; }
}