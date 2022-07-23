namespace MVC.Models.Requests
{
    public class AddItemRequest
    {
        [Required]
        [StringLength(1000)]
        public string Name { get; set; } = null!;
        [Required]
        [Range(0, 1000000)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 100000)]
        public int Weight { get; set; }
        [Required]
        [Range(0, 100000)]
        public double Size { get; set; }
        [Required]
        public int CatalogMaterialId { get; set; }
        [Required]
        public int CatalogSourceId { get; set; }
        [Required]
        [StringLength(100)]
        public string PictureFileName { get; set; } = null!;
        [Required]
        [Range(0, 1000000)]
        public int AvailableStock { get; set; }
    }
}
