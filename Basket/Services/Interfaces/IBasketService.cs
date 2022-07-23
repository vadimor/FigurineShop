using Basket.Models.Dtos;

namespace Basket.Services.Interfaces
{
    public interface IBasketService
    {
        Task AddAsync(CatalogItemDto catalogItemDto, int countItem, string userId);
        Task RemoveAsync(CatalogItemDto catalogItemDto, string userId);
        Task<BasketDataSerializedDto> GetAsync(string userId);
    }
}