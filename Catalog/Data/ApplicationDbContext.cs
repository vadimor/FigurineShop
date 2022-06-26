using Catalog.Data.Entities;
using Catalog.Data.EntityConfigurations;

namespace Catalog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CatalogItem> CatalogItems { get; set; } = null!;
        public DbSet<CatalogMaterial> CatalogMaterials { get; set; } = null!;
        public DbSet<CatalogSource> CatalogSources { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CatalogMaterialEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogSourceEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());
        }
    }
}
