﻿using Catalog.Services.Interfaces;
using Catalog.Repositories.Interfaces;
using Catalog.Data;
using Catalog.Models.Dtos;
using Catalog.Models.Response;

namespace Catalog.Services
{
    public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
    {
        private readonly ICatalogItemRepository _repository;
        private readonly IMapper _mapper;
        public CatalogItemService(
            IMapper mapper,
            ICatalogItemRepository catalogItemService,
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger)
            :base(dbContextWrapper,logger)
        { 
            _mapper = mapper;
            _repository = catalogItemService;
        }

        public async Task<CatalogItemDto> AddAsync(string name, decimal price, int weight, double size, int catalogMaterialId, int catalogSourceId, string pictureFileName, int availableStock)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _repository.AddAsync(name, price, weight, size, catalogMaterialId, catalogSourceId, pictureFileName, availableStock);
                return _mapper.Map<CatalogItemDto>(result);
            });
        }

        public async Task<ItemsListResponse<CatalogItemDto>> GetItemsAsync()
        {
            var items = await _repository.GetItemsAsync();
            return new ItemsListResponse<CatalogItemDto> { Count = items.TotalCount, Data = items.Data.Select(x => _mapper.Map<CatalogItemDto>(x)) }; 
        }

        public async Task<CatalogItemDto?> RemoveAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _repository.RemoveAsync(id);
                return _mapper.Map<CatalogItemDto>(result);
            });
        }

        public async Task<CatalogItemDto?> UpdateAsync(int id, string name, decimal price, int weight, double size, int catalogMaterialId, int catalogSourceId, string pictureFileName, int availableStock)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _repository.UpdateAsync(id, name, price, weight, size, catalogMaterialId, catalogSourceId, pictureFileName, availableStock);
                return _mapper.Map<CatalogItemDto>(result);
            }
            );
        }
    }
}
