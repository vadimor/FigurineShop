using Catalog.Models.Dtos;
using Catalog.Models.Response;

namespace Catalog.Services.Interfaces;

public interface ICatalogItemService
{
    Task<CatalogItemDto?> GetItemAsync(int id);
    Task<IEnumerable<CatalogItemDto>> GetItemsAsync();
    Task<CatalogItemDto> AddAsync(string name, decimal price, int weight, double size, int catalogMaterialId, int catalogSourceId, string pictureFileName, int availableStock);
    Task<CatalogItemDto?> RemoveAsync(int id);
    Task<CatalogItemDto?> UpdateAsync(int id, string name, decimal price, int weight, double size, int catalogMaterialId, int catalogSourceId, string pictureFileName, int availableStock);
}