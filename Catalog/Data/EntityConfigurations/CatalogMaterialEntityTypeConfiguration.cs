using Catalog.Data.Entities;

namespace Catalog.Data.EntityConfigurations
{
    public class CatalogMaterialEntityTypeConfiguration
        : IEntityTypeConfiguration<CatalogMaterial>
    {
        public void Configure(EntityTypeBuilder<CatalogMaterial> builder)
        {
            builder.ToTable("CatalogMaterial");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseHiLo("catalog_material_hilo")
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
