using AutoMapper;
using Comment.Data.Entities;
using Comment.Models.Dtos;
using Comment.Models.Request;

namespace Comment.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CommentEntity, CommentDto>();
            CreateMap<AddRequest, CommentEntity>();
        }
    }
}
