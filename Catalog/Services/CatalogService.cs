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
            }

            var page = await _repository.GetByPageAsync(pageIndex, pageSize, materialFilter, sourceFilter, 0,0,0,0,0,0);
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
