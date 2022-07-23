using MVC.ViewModels;

namespace MVC.Models.Requests
{
    public class RemoveBasketItemRequest
    {
        public CatalogItem CatalogItem { get; set; } = null!;
    }
}
