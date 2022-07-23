namespace MVC.ViewModels.Admin
{
    public class AddItemPageViewModel
    {
        public IEnumerable<SelectListItem> Materials { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Sources { get; set; } = Enumerable.Empty<SelectListItem>();
        public int? CatalogMaterialId { get; set; }
        public int? CatalogSourceId { get; set; }
    }
}
