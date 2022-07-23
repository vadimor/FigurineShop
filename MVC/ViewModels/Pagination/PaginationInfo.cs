using MVC.ViewModels.CatalogViewModels;

namespace MVC.ViewModels.Pagination;

public class PaginationInfo
{
    public int? MaterialFilterApplied { get; set; }
    public int? SourceFilterApplied { get; set; }
    public int? PriceMinFilterApplied { get; set; }
    public int? PriceMaxFilterApplied { get; set; }
    public int? WeightMinFilterApplied { get; set; }
    public int? WeightMaxFilterApplied { get; set; }
    public int? SizeMinFilterApplied { get; set; }
    public int? SizeMaxFilterApplied { get; set; }
    public CatalogTypeSorting? SortingApplied { get; set; }
    public int TotalItems { get; set; }
    public int ItemsPerPage { get; set; }
    public int ItemsPerPageRequest { get; set; }
    public int ActualPage { get; set; }
    public int TotalPages { get; set; }
    public string? Previous { get; set; }
    public string? Next { get; set; }
}
