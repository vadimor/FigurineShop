using Catalog.Data;
using Catalog.Models.Dtos;
using Catalog.Models.Response;
using Catalog.Repositories.Interfaces;
using Catalog.Services.Interfaces;

namespace Catalog.Services
{
    public class CatalogMaterialService : BaseDataService<ApplicationDbContext>, ICatalogMaterialService
    {
        private readonly IMapper _mapper;
        private readonly ICatalogMaterialRepository _repository;

        public CatalogMaterialService(
            IMapper mapper,
            ICatalogMaterialRepository repository,
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger
        ) : base(dbContextWrapper, logger)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CatalogMaterialDto> AddAsync(string name)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _repository.AddAsync(name);
                return _mapper.Map<CatalogMaterialDto>(result);
            });
        }

        public async Task<ItemsListResponse<CatalogMaterialDto>> GetMaterialsAsync()
        {
            var result = await _repository.GetMaterialsAsync();
            return new ItemsListResponse<CatalogMaterialDto>
            {
                Count = result.TotalCount,
                Data = result.Data.Select(x => _mapper.Map<CatalogMaterialDto>(x)).ToList(),
            };
        }

        public async Task<CatalogMaterialDto?> RemoveAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _repository.RemoveAsync(id);
                return _mapper.Map<CatalogMaterialDto>(result);
            });
        }

        public async Task<CatalogMaterialDto?> UpdateAsync(int id, string name)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _repository.UpdateAsync(id, name);
                return _mapper.Map<CatalogMaterialDto>(result);
            }
            );
        }
    }
}
