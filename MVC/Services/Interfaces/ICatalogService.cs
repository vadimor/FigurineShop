using MVC.ViewModels;

namespace MVC.Services.Interfaces;

public interface ICatalogService
{
    Task<Catalog> GetCatalogItems(int page, int take, int? material, int? source);
    Task<IEnumerable<SelectListItem>> GetMaterials();
    Task<IEnumerable<SelectListItem>> GetSources();
}
