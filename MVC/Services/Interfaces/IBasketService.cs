using MVC.ViewModels;

namespace MVC.Services.Interfaces
{
    public interface IBasketService
    {
        Task AddBasket(CatalogItem catalogItem, int countItems);
        Task<BasketData> GetBasket();
    }
}