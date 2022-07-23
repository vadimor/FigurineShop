namespace MVC.ViewModels.Admin
{
    public class SourceListPageViewModel
    {
        public IEnumerable<CatalogSource> Sources { get; set; } = new List<CatalogSource>();
    }
}
