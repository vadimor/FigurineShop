using Catalog.Data;
using Catalog.Data.Entities;
using Catalog.Data.Enums;

namespace Catalog.Repositories.Interfaces
{
    public interface ICatalogItemRepository
    {
        Task<PaginatedItems<CatalogItem>> GetByPageAsync(
            int pageIndex,
            int pageSize,
            int? materialFilter,
            int? sourceFilter,
            decimal? priceMin,
            decimal? priceMax,
            int? weightMin,
            int? weightMax,
            double? sizeMin,
            double? sizeMax,
            CatalogTypeSorting? sorting);

        Task<CatalogItem?> GetItem(int id);
        Task<IEnumerable<CatalogItem>> GetItemsAsync();
        Task<CatalogItem> AddAsync(string name, decimal price, int weight, double size, int catalogMaterialId, int catalogSourceId, string pictureFileName, int availableStock);
        Task<CatalogItem?> RemoveAsync(int id);
        Task<CatalogItem?> UpdateAsync(int id, string name, decimal price, int weight, double size, int catalogMaterialId, int catalogSourceId, string pictureFileName, int availableStock);
    }
}
