using api.Contracts;
using api.DataTransferObjects.PostDtos;
using api.DataTransferObjects.UserDtos;
using api.DataTransferObjects.ValueResolvers;
using api.Models;
using AutoMapper;

namespace api.DataTransferObjects
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Post, PostDto>()
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
              .ForMember(dest => dest.LikeCount, opt => opt.MapFrom<LikesResolver>());
            ;
            CreateMap<AddUserDto, AppUser>();
            CreateMap<AppUser, UserDto>();

        }
        
    }

    
}
