namespace MVC.ViewModels.Admin
{
    public class MaterialListPageViewModel
    {
        public IEnumerable<CatalogMaterial> Materials { get; set; } = new List<CatalogMaterial>();
    }
}
