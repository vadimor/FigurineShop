namespace Catalog.Models.Requests
{
    public class PaginatedItemsRequest<TFilters>
        where TFilters : notnull
    {
        public int PageSize { get; set; }
        
        public int PageIndex { get; set; }

        public Dictionary<TFilters, int>? Filters { get; set; }
    }
}
