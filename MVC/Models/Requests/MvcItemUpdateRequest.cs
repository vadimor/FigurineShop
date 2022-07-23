namespace MVC.Models.Requests
{
    public class MvcItemUpdateRequest
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

        public int MaterialApplied { get; set; }

        public int SourceApplied { get; set; }

        public string PictureFileName { get; set; } = null!;
        [Range(0, 1000000)]
        public int AvailableStock { get; set; }
    }
}
