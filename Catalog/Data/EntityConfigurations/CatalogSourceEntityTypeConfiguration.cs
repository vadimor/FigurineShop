using Catalog.Data.Entities;

namespace Catalog.Data.EntityConfigurations
{
    public class CatalogSourceEntityTypeConfiguration
        : IEntityTypeConfiguration<CatalogSource>
    {
        public void Configure(EntityTypeBuilder<CatalogSource> builder)
        {
            builder.ToTable("CatalogSource");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseHiLo("catalog_source_hilo")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
