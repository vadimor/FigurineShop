using Catalog.Data.Entities;

namespace Catalog.Data.EntityConfigurations
{
    public class CatalogItemEntityTypeConfiguration
        : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("CatalogItem");

            builder.Property(x => x.Id)
                .UseHiLo("catalog_item_hilo")
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.Weight)
                .IsRequired();

            builder.Property(x => x.Size)
                .IsRequired();

            builder.Property(x => x.PictureFileName)
                .IsRequired();

            builder.Property(x => x.AvailableStock)
                .IsRequired();

            builder.HasOne(x => x.Material)
                .WithMany()
                .HasForeignKey(x => x.CatalogMaterialId);

            builder.HasOne(x => x.Source)
                .WithMany()
                .HasForeignKey(x => x.CatalogSourceId);
        }
    }
}
