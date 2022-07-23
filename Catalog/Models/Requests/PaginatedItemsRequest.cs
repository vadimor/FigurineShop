﻿namespace Catalog.Models.Requests
{
    public class PaginatedItemsRequest<TFilters, TSorting>
        where TFilters : notnull
        where TSorting : Enum
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public Dictionary<TFilters, int>? Filters { get; set; }

        public TSorting? Sorting { get; set; }
    }
}
