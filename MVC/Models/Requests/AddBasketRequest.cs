using MVC.ViewModels;

namespace MVC.Models.Requests
{
    public class AddBasketRequest
    {
        public CatalogItem CatalogItem { get; set; } = null!;
        public int CountItems { get; set; }
    }
}
