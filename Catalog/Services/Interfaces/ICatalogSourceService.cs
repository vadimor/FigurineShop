using Catalog.Models.Dtos;
using Catalog.Models.Response;

namespace Catalog.Services.Interfaces
{
    public interface ICatalogSourceService
    {
        Task<ItemsListResponse<CatalogSourceDto>> GetSourcesAsync();
        Task<CatalogSourceDto> AddAsync(string name);
        Task<CatalogSourceDto?> RemoveAsync(int id);
        Task<CatalogSourceDto?> UpdateAsync(int id, string name);
    }
}
