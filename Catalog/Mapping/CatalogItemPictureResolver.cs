using Catalog.Configurations;
using Catalog.Data.Entities;
using Catalog.Models.Dtos;

namespace Catalog.Mapping;

public class CatalogItemPictureResolver : IMemberValueResolver<CatalogItem, CatalogItemDto, string, string>
{
    private readonly CatalogConfig _config;

    public CatalogItemPictureResolver(IOptionsSnapshot<CatalogConfig> config)
    {
        _config = config.Value;
    }

    public string Resolve(CatalogItem source, CatalogItemDto destination, string sourceMember, string destMember, ResolutionContext context)
    {
        return $"{_config.CdnHost}/{_config.ImgUrl}/{sourceMember}";
    }
}