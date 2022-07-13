using Infrastructure.Services.Interfaces;
using MVC.Models.Requests;
using MVC.Models.Response;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services
{
    public class BasketService : IBasketService
    {
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IHttpClientService _httpClient;
        private readonly ILogger<CatalogService> _logger;
        private readonly IOptions<AppSettings> _settings;

        public BasketService(IJsonSerializer jsonSerializer, IHttpClientService httpClient, ILogger<CatalogService> logger, IOptions<AppSettings> settings)
        {
            _jsonSerializer = jsonSerializer;
            _httpClient = httpClient;
            _logger = logger;
            _settings = settings;
        }

        public async Task AddBasket(CatalogItem catalogItem, int countItems)
        {
            var result = await _httpClient.SendAsync<object, AddBasketRequest>($"{_settings.Value.BasketUrl}/Add",
            HttpMethod.Post,
            new AddBasketRequest
            {
                catalogItem = catalogItem,
                countItems = countItems
            });
        }

        public async Task<BasketData> GetBasket()
        {
            var result = await _httpClient.SendAsync<BasketDataSerializedResponse, object>($"{_settings.Value.BasketUrl}/Get",
            HttpMethod.Post,
            null
            );

            _logger.LogInformation($"result: {result}");

            var basketData = new BasketData
            {
                Data = new Dictionary<CatalogItem, int>()
            };

            foreach (var item in result.Data)
            {
                basketData.Data.Add(
                _jsonSerializer.Deserialize<CatalogItem>(item.Key),
                item.Value
                );
            }

            return basketData;
        }
    }
}
