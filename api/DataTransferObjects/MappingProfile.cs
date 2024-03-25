using api.Models;
using AutoMapper;

namespace api.DataTransferObjects
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
        CreateMap<Post, PostDto>()
         .ForMember(p => p.Username, opt => opt.MapFrom(p => p.User.Username));
        }
    }
}
