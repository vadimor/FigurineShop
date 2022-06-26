namespace Catalog.Data.Entities
{
    public class CatalogItem
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public double Size { get; set; }
        
        public int CatalogMaterialId { get; set; }
        
        public CatalogMaterial Material { get; set; } = null!;
        
        public int CatalogSourceId { get; set; }
        
        public CatalogSource Source { get; set; } = null!;

        public string PictureFileName { get; set; } = null!;

        public int AvailableStock { get; set; }
    }
}
