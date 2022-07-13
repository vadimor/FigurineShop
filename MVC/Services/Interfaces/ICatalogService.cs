using MVC.ViewModels;

namespace MVC.Services.Interfaces;

public interface ICatalogService
{
    Task<Catalog> GetCatalogItems(int page, int take, int? material, int? source, int? priceMin, int? priceMax, int? weightMin, int? weightMax, int? sizeMin, int? sizeMax);
    Task<IEnumerable<SelectListItem>> GetMaterials();
    Task<IEnumerable<SelectListItem>> GetSources();
    Task<CatalogItem> GetItem(int id);
}
