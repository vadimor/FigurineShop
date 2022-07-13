using Catalog.Models.Dtos;
using Catalog.Models.Response;
using Catalog.Services.Interfaces;
using Catalog.Data;
using Catalog.Repositories.Interfaces;
using Catalog.Models.Enums;

namespace Catalog.Services
{
    public class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
    {
        private readonly IMapper _mapper;
        private readonly ICatalogItemRepository _repository;

        public CatalogService(
            IMapper mapper,
            ICatalogItemRepository repository,
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger
        ) : base(dbContextWrapper, logger)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PaginatedItemsResponse<CatalogItemDto>?> GetCatalogItemsAsync(int pageSize, int pageIndex, Dictionary<CatalogTypeFilter, int>? filters)
        {
            int? materialFilter = null;
            int? sourceFilter = null;
            int? priceMinFilter = null;
            int? priceMaxFilter = null;
            int? weightMinFilter = null;
            int? weightMaxFilter = null;
            int? sizeMinFilter = null;
            int? sizeMaxFilter = null;

            if (filters != null)
            {
                if (filters.TryGetValue(CatalogTypeFilter.Material, out var material))
                {
                    materialFilter = material;
                }

                if (filters.TryGetValue(CatalogTypeFilter.Source, out var source))
                {
                    sourceFilter = source;
                }
                
                if (filters.TryGetValue(CatalogTypeFilter.PriceMin, out var priceMin))
                {
                    priceMinFilter = priceMin;
                }
                
                if (filters.TryGetValue(CatalogTypeFilter.PriceMax, out var priceMax))
                {
                    priceMaxFilter = priceMax;
                }

                if (filters.TryGetValue(CatalogTypeFilter.WeightMin, out var weightMin))
                {
                    weightMinFilter = weightMin;
                }

                if (filters.TryGetValue(CatalogTypeFilter.WeightMax, out var weightMax))
                {
                    weightMaxFilter = weightMax;
                }
                
                if (filters.TryGetValue(CatalogTypeFilter.SizeMin, out var sizeMin))
                {
                    sizeMinFilter = sizeMin;
                }

                if (filters.TryGetValue(CatalogTypeFilter.SizeMax, out var sizeMax))
                {
                    sizeMaxFilter = sizeMax;
                }
            }

            var page = await _repository.GetByPageAsync(
                pageIndex, pageSize, materialFilter, sourceFilter, priceMinFilter, priceMaxFilter, weightMinFilter, weightMaxFilter, sizeMinFilter, sizeMaxFilter);
            
            if (page == null)
            {
                return null;
            }

            var result = new PaginatedItemsResponse<CatalogItemDto>()
            {
                Count = page.TotalCount,
                Data = page.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            return result;
        }
    }
}
