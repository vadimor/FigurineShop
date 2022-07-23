namespace MVC.ViewModels.Admin
{
    public class ItemUpdatePageViewModel
    {
        public CatalogItem? Item { get; set; }
        public IEnumerable<SelectListItem> Materials { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Sources { get; set; } = Enumerable.Empty<SelectListItem>();
        public int? MaterialApplied { get; set; }
        public int? SourceApplied { get; set; }
        public string? PictureFileName { get; set; }
    }
}
