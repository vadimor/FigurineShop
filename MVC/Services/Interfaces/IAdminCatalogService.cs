using MVC.Models.Requests;
using MVC.ViewModels;

namespace MVC.Services.Interfaces
{
    public interface IAdminCatalogService
    {
        Task<CatalogItem?> AddItem(AddItemRequest request);
        Task<CatalogMaterial?> AddMaterial(AddRequest request);
        Task<CatalogSource?> AddSource(AddRequest request);
        Task<CatalogItem> GetItem(int id);
        Task<IEnumerable<CatalogItem>> GetItems();
        Task<CatalogMaterial> GetMaterial(int id);
        Task<IEnumerable<CatalogMaterial>> GetMaterials();
        Task<IEnumerable<SelectListItem>> GetMaterialSelectList();
        Task<CatalogSource> GetSource(int id);
        Task<IEnumerable<CatalogSource>> GetSources();
        Task<IEnumerable<SelectListItem>> GetSourceSelectList();
        Task<CatalogItem?> RemoveItem(RemoveRequest request);
        Task<CatalogMaterial?> RemoveMaterial(RemoveRequest request);
        Task<CatalogSource?> RemoveSource(RemoveRequest request);
        Task<CatalogItem?> UpdateItem(UpdateItemRequest request);
        Task<CatalogMaterial?> UpdateMaterial(UpdateRequest request);
        Task<CatalogSource?> UpdateSource(UpdateRequest request);
    }
}