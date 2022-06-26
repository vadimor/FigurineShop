using Catalog.Models.Dtos;
using Catalog.Models.Response;

namespace Catalog.Services.Interfaces
{
    public interface ICatalogMaterialService
    {
        Task<ItemsListResponse<CatalogMaterialDto>> GetMaterialsAsync();
        Task<CatalogMaterialDto> AddAsync(string name);
        Task<CatalogMaterialDto?> RemoveAsync(int id);
        Task<CatalogMaterialDto?> UpdateAsync(int id, string name);
    }
}
