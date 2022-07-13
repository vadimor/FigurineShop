using Basket.Models.Dtos;

namespace Basket.Models.Requests
{
    public class AddRequest
    {
        public CatalogItemDto catalogItem { get; set; }
        public int countItems { get; set; }
    }
}
