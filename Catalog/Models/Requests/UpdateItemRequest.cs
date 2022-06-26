namespace Catalog.Models.Requests
{
    public class UpdateItemRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public double Size { get; set; }

        public int CatalogMaterialId { get; set; }

        public int CatalogSourceId { get; set; }

        public string PictureFileName { get; set; } = null!;

        public int AvailableStock { get; set; }
    }
}
