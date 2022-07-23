namespace MVC.Models.Requests
{
    public class UpdateItemRequest
    {
        [Required]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = null!;
        [Range(0, 1000000)]
        public decimal Price { get; set; }
        [Range(0, 100000)]
        public int Weight { get; set; }
        [Range(0, 100000)]
        public double Size { get; set; }

        public int CatalogMaterialId { get; set; }

        public int CatalogSourceId { get; set; }
        [StringLength(100)]
        public string PictureFileName { get; set; } = null!;
        [Range(0, 1000000)]
        public int AvailableStock { get; set; }
    }
}
