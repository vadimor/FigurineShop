using MVC.ViewModels;

namespace MVC.Services.Interfaces
{
    public interface IBasketService
    {
        Task AddBasket(CatalogItem catalogItem, int countItems);
        Task RemoveBasket(CatalogItem catalogItem);
        Task<BasketData> GetBasket();
    }
}