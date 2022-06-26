using Catalog.Data.Entities;
using Catalog.Models.Dtos;

namespace Catalog.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CatalogMaterial, CatalogMaterialDto>();
            CreateMap<CatalogSource, CatalogSourceDto>();
            CreateMap<CatalogItem, CatalogItemDto>()
                .ForMember(x => x.PictureUrl, opt
                    => opt.MapFrom<CatalogItemPictureResolver, string>(x => x.PictureFileName));
        }
    }
}
