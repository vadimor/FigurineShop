namespace MVC.ViewModels;

public record CatalogItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Weight { get; set; }

    public double Size { get; set; }

    public CatalogMaterial Material { get; set; } = null!;

    public CatalogSource Source { get; set; } = null!;

    public string PictureUrl { get; set; } = null!;

    public int AvailableStock { get; set; }
}