using MVC.ViewModels.Pagination;

namespace MVC.ViewModels.CatalogViewModels;

public class IndexViewModel
{
    public IEnumerable<CatalogItem> CatalogItems { get; set; }
    public IEnumerable<SelectListItem> Materials { get; set; }
    public IEnumerable<SelectListItem> Sources { get; set; }
    public int? MaterialFilterApplied { get; set; }
    public int? SourceFilterApplied { get; set; }
    public int? PriceMinFilterApplied { get; set; }
    public int? PriceMaxFilterApplied { get; set; }
    public int? WeightMinFilterApplied { get; set; }
    public int? WeightMaxFilterApplied { get; set; }
    public int? SizeMinFilterApplied { get; set; }
    public int? SizeMaxFilterApplied { get; set; }
    public PaginationInfo PaginationInfo { get; set; }
}
