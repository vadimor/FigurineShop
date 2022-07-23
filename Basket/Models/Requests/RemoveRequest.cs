using Basket.Models.Dtos;

namespace Basket.Models.Requests
{
    public class RemoveRequest
    {
        public CatalogItemDto CatalogItem { get; set; } = null!;
    }
}
