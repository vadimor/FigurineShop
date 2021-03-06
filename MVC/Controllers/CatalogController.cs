using MVC.Services.Interfaces;
using MVC.ViewModels.CatalogViewModels;
using MVC.ViewModels.Pagination;

namespace MVC.Controllers;

public class CatalogController : Controller
{
    private readonly ICatalogService _catalogService;

    public CatalogController(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    public async Task<IActionResult> Index(
        CatalogTypeSorting? sortingApplied,
        int? materialFilterApplied,
        int? sourceFilterApplied,
        int? priceMinFilterApplied,
        int? priceMaxFilterApplied,
        int? weightMinFilterApplied,
        int? weightMaxFilterApplied,
        int? sizeMinFilterApplied,
        int? sizeMaxFilterApplied,
        int? page,
        int? itemsPage)
    {
        page ??= 0;
        itemsPage ??= 9;
        var catalog = await _catalogService.GetCatalogItems(
            page.Value,
            itemsPage.Value,
            materialFilterApplied,
            sourceFilterApplied,
            priceMinFilterApplied,
            priceMaxFilterApplied,
            weightMinFilterApplied,
            weightMaxFilterApplied,
            sizeMinFilterApplied,
            sizeMaxFilterApplied,
            sortingApplied);

        if (catalog == null)
        {
            return View("Error");
        }

        var info = new PaginationInfo()
        {
            MaterialFilterApplied = materialFilterApplied,
            SourceFilterApplied = sourceFilterApplied,
            PriceMinFilterApplied = priceMinFilterApplied,
            PriceMaxFilterApplied = priceMaxFilterApplied,
            WeightMinFilterApplied = weightMinFilterApplied,
            WeightMaxFilterApplied = weightMaxFilterApplied,
            SizeMinFilterApplied = sizeMinFilterApplied,
            SizeMaxFilterApplied = sizeMaxFilterApplied,
            SortingApplied = sortingApplied,
            ItemsPerPageRequest = itemsPage.Value,
            ActualPage = page.Value,
            ItemsPerPage = catalog.Data!.Count,
            TotalItems = catalog.Count,
            TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsPage.Value)
        };
        var vm = new IndexViewModel()
        {
            CatalogItems = catalog.Data,
            Materials = await _catalogService.GetMaterials(),
            Sources = await _catalogService.GetSources(),
            Sorting = _catalogService.GetSortingTypes(),
            PaginationInfo = info
        };

        vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : string.Empty;
        vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : string.Empty;

        return View(vm);
    }

    public async Task<IActionResult> ItemInfoPage(int id)
    {
        var vm = new ItemInfoPageViewModel
        {
            Item = await _catalogService.GetItem(id)
        };

        return View(vm);
    }
}