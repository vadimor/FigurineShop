using Catalog.Models.Dtos;
using Catalog.Models.Response;

namespace Catalog.Services.Interfaces
{
    public interface ICatalogMaterialService
    {
        Task<IEnumerable<CatalogMaterialDto>> GetMaterialsAsync();
        Task<CatalogMaterialDto?> GetMaterialAsync(int id);
        Task<CatalogMaterialDto> AddAsync(string name);
        Task<CatalogMaterialDto?> RemoveAsync(int id);
        Task<CatalogMaterialDto?> UpdateAsync(int id, string name);
    }
}
