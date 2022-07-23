using MVC.ViewModels;
using MVC.ViewModels.CatalogViewModels;

namespace MVC.Services.Interfaces;

public interface ICatalogService
{
    IEnumerable<SelectListItem> GetSortingTypes();
    Task<Catalog> GetCatalogItems(int page, int take, int? material, int? source, int? priceMin, int? priceMax, int? weightMin, int? weightMax, int? sizeMin, int? sizeMax, CatalogTypeSorting? sorting);
    Task<IEnumerable<SelectListItem>> GetMaterials();
    Task<IEnumerable<SelectListItem>> GetSources();
    Task<CatalogItem> GetItem(int id);
}
