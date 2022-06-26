using Catalog.Data.Entities;

namespace Catalog.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.CatalogMaterials.Any())
            {
                await context.CatalogMaterials.AddRangeAsync(GetPreconfiguredCatalogMaterials());

                await context.SaveChangesAsync();
            }

            if (!context.CatalogSources.Any())
            {
                await context.CatalogSources.AddRangeAsync(GetPreconfiguredCatalogSources());

                await context.SaveChangesAsync();
            }

            if (!context.CatalogItems.Any())
            {
                await context.CatalogItems.AddRangeAsync(GetPreconfiguredItems());

                await context.SaveChangesAsync();
            }


        }

        private static IEnumerable<CatalogMaterial> GetPreconfiguredCatalogMaterials()
        {
            return new List<CatalogMaterial>()
            {
            new CatalogMaterial() { Name = "PVC" },
            new CatalogMaterial() { Name = "ABS" },
            new CatalogMaterial() { Name = "Resin" },
            new CatalogMaterial() { Name = "Polystone" }
            };
        }

        private static IEnumerable<CatalogSource> GetPreconfiguredCatalogSources()
        {
            return new List<CatalogSource>()
            {
            new CatalogSource() { Name = "Rebuild of Evangelion" },
            new CatalogSource() { Name = "Kimetsu no Yaiba" },
            new CatalogSource() { Name = "Re:ZERO -Starting Life in Another World" },
            new CatalogSource() { Name = "Shingeki no Kyojin" },
            new CatalogSource() { Name = "Kagamine Rin/Len" },
            new CatalogSource() { Name = "Kantai Collection" },
            new CatalogSource() { Name = "BAKI" },
            new CatalogSource() { Name = "Star Wars" },
            new CatalogSource() { Name = "Fairy Tail" },
            new CatalogSource() { Name = "SSSS.DYNAZENON" },
            new CatalogSource() { Name = "Fate/Grand Order" },
            };
        }

        private static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {

            return new List<CatalogItem>()
            {
            new CatalogItem { Name = "Parfom R! Object To-lick", Price = 192.1M, Weight = 300, Size = 14, CatalogSourceId = 1, CatalogMaterialId = 1, AvailableStock = 100, PictureFileName = "1.png" },
            new CatalogItem { Name = "Figuarts Mini Demon Slayer: AKAZA", Price = 20M, Weight = 200, Size = 9, CatalogSourceId = 2, CatalogMaterialId = 1, AvailableStock = 100, PictureFileName = "2.png" },
            new CatalogItem { Name = "Figuarts Mini Re:Zero - Rem", Price = 20M, Weight = 200, Size = 9, CatalogSourceId = 3, CatalogMaterialId = 1, AvailableStock = 100, PictureFileName = "3.png" },
            new CatalogItem { Name = "ARTFX J Levi Fortitude ver.", Price = 200M, Weight = 1350, Size = 17.1d, CatalogSourceId = 4, CatalogMaterialId = 1, AvailableStock = 100, PictureFileName = "4.png" },
            new CatalogItem { Name = "HELLO! GOOD SMILE Kagamine Len", Price = 100M, Weight = 200, Size = 10, CatalogSourceId = 5, CatalogMaterialId = 2, AvailableStock = 100, PictureFileName = "5.png" },
            new CatalogItem { Name = "Kumano Kai-II", Price = 300, Weight = 1000, Size = 22.5d, CatalogSourceId = 6, CatalogMaterialId = 1, AvailableStock = 100, PictureFileName = "6.png" },
            new CatalogItem { Name = "POP UP PARADE Baki Hanma", Price = 350M, Weight = 460, Size = 17, CatalogSourceId = 7, CatalogMaterialId = 4, AvailableStock = 100, PictureFileName = "7.png" },
            new CatalogItem { Name = "ARTFX TECH THE BAD BATCH", Price = 400, Weight = 1350, Size = 28, CatalogSourceId = 8, CatalogMaterialId = 1, AvailableStock = 100, PictureFileName = "8.png" },
            new CatalogItem { Name = "POP UP PARADE Natsu Dragneel", Price = 250M, Weight = 460, Size = 17, CatalogSourceId = 9, CatalogMaterialId = 1, AvailableStock = 100, PictureFileName = "9.png" },
            new CatalogItem { Name = "DX Combine Dynazenon", Price = 300M, Weight = 600, Size = 25, CatalogSourceId = 10, CatalogMaterialId = 2, AvailableStock = 100, PictureFileName = "10.png" },
            new CatalogItem { Name = "Fate/Grand Order Ruler/Qin 1/7 Scale Figure", Price = 600M, Weight = 1000, Size = 32, CatalogSourceId = 11, CatalogMaterialId = 1, AvailableStock = 100, PictureFileName = "11.png" },
            new CatalogItem { Name = "Foreigner/Katsushika Hokusai: Travel Portrait Ver.", Price = 200M, Weight = 1000, Size = 25, CatalogSourceId = 11, CatalogMaterialId = 2, AvailableStock = 100, PictureFileName = "12.png" }
            };
        }
    }
}
