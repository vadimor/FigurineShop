using Basket.Models;
using Basket.Models.Dtos;
using Basket.Services.Interfaces;

namespace Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly ICacheService _cacheService;
        private readonly ILogger<BasketService> _logger;
        private readonly IJsonSerializer _jsonSerializer;
        public BasketService(ICacheService cacheService, ILogger<BasketService> logger, IJsonSerializer jsonSerializer)
        {
            _cacheService = cacheService;
            _logger = logger;
            _jsonSerializer = jsonSerializer;
        }

        public async Task AddAsync(CatalogItemDto catalogItemDto, int countItem, string userId)
        {
            var originalData = await _cacheService.GetAsync<BasketDataSerializedDto>(userId);

            if (originalData is null)
            {
                originalData = new BasketDataSerializedDto
                {
                    Data = new Dictionary<String, int>()
                };
            }
            var serializedItem = _jsonSerializer.Serialize(catalogItemDto);
            if (originalData.Data.ContainsKey(serializedItem))
            {
                originalData.Data[serializedItem] = countItem;
            }
            else
            {
                originalData.Data.Add(serializedItem, countItem);
            }

            await _cacheService.AddOrUpdateAsync(userId, originalData);
        }

        public async Task<BasketDataSerializedDto> GetAsync(string userId)
        {
            return await _cacheService.GetAsync<BasketDataSerializedDto>(userId);
        }
    }
}
