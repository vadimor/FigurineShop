using Catalog.Models.Dtos;
using Catalog.Models.Enums;
using Catalog.Models.Response;

namespace Catalog.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>?> GetCatalogItemsAsync(int pageSize, int pageIndex, Dictionary<CatalogTypeFilter, int>? filters, CatalogTypeSorting? sorting);
}