using Catalog.Models.Dtos;
using Catalog.Models.Response;
using Catalog.Services.Interfaces;
using Catalog.Data;
using Catalog.Repositories.Interfaces;

namespace Catalog.Services
{
    public class CatalogSourceService : BaseDataService<ApplicationDbContext>, ICatalogSourceService
    {
        private readonly IMapper _mapper;
        private readonly ICatalogSourceRepository _repository;

        public CatalogSourceService(
            IMapper mapper,
            ICatalogSourceRepository repository,
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger
        ) : base(dbContextWrapper, logger)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<CatalogSourceDto> AddAsync(string name)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _repository.AddAsync(name);
                return _mapper.Map<CatalogSourceDto>(result);
            });
        }

        public async Task<ItemsListResponse<CatalogSourceDto>> GetSourcesAsync()
        {
            var result = await _repository.GetSourcesAsync();
            return new ItemsListResponse<CatalogSourceDto>
            {
                Count = result.TotalCount,
                Data = result.Data.Select(x => _mapper.Map<CatalogSourceDto>(x)).ToList(),
            };
        }

        public async Task<CatalogSourceDto?> RemoveAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _repository.RemoveAsync(id);
                return _mapper.Map<CatalogSourceDto>(result);
            });
        }

        public async Task<CatalogSourceDto?> UpdateAsync(int id, string name)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _repository.UpdateAsync(id, name);
                return _mapper.Map<CatalogSourceDto>(result);
            }
            );
        }
    }
}
