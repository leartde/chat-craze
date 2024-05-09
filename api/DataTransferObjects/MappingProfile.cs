using api.DataTransferObjects.BookmarkDtos;
using api.DataTransferObjects.CommentDtos;
using api.DataTransferObjects.FriendshipDtos;
using api.DataTransferObjects.InvitationDtos;
using api.DataTransferObjects.LikeDtos;
using api.DataTransferObjects.NotificationDtos;
using api.DataTransferObjects.PostDtos;
using api.DataTransferObjects.PostDtos.api.DataTransferObjects.PostDtos;
using api.DataTransferObjects.ReplyDtos;
using api.DataTransferObjects.UserDtos;
using api.DataTransferObjects.UsersInterestsDtos;
using api.DataTransferObjects.ValueResolvers;
using api.Models;
using AutoMapper;

namespace api.DataTransferObjects
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Post, PostDto>()
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User!.UserName))
              .ForMember(dest => dest.LikeCount, opt => opt.MapFrom<LikesResolver>());

            CreateMap<AddPostDto, Post>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
                
            
            CreateMap<AddUserDto, AppUser>();
            CreateMap<UpdateUserDto, AppUser>();
            CreateMap<AppUser, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom<RolesResolver>());
            
            CreateMap<Invitation, InvitationDto>()
                .ForMember(dest => dest.SenderUsername, opt => opt.MapFrom(src => src.Sender!.UserName))
                .ForMember(dest => dest.ReceiverUsername, opt => opt.MapFrom(src => src.Receiver!.UserName));
                
            CreateMap<Notification, NotificationDto>()
                .ForMember(dest => dest.SenderUsername, opt => opt.MapFrom(src => src.Sender!.UserName))
                .ForMember(dest => dest.ReceiverUsername, opt => opt.MapFrom(src => src.Receiver!.UserName));


            CreateMap<Friendship, FriendshipDto>()
                .ForMember(dest => dest.FriendOneUsername, opt => opt.MapFrom(src => src.FriendOne!.UserName))
                .ForMember(dest => dest.FriendOneAvatar, opt => opt.MapFrom(src => src.FriendOne!.AvatarUrl))
                .ForMember(dest => dest.FriendTwoUsername, opt => opt.MapFrom(src => src.FriendTwo!.UserName))
                .ForMember(dest => dest.FriendTwoAvatar, opt => opt.MapFrom(src => src.FriendTwo!.AvatarUrl));

            CreateMap<Like, LikeDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User!.UserName))
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Post!.Title));
        

            CreateMap<Bookmark, BookmarkDto>()
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Post!.Title))
                .ForMember(dest => dest.PostImage, opt => opt.MapFrom(src => src.Post!.ImageUrl));

            CreateMap<UsersInterests, UsersInterestsDto>().ReverseMap();

            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User!.UserName))
                .ForMember(dest => dest.UserAvatar, opt => opt.MapFrom(src => src.User!.AvatarUrl))
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Post!.Title));
            CreateMap<AddCommentDto, Comment>();
            CreateMap<UpdateCommentDto, Comment>();

            CreateMap<Reply, ReplyDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User!.UserName))
                .ForMember(dest => dest.UserAvatar, opt => opt.MapFrom(src => src.User!.AvatarUrl));
            CreateMap<AddReplyDto, Reply>();
        }
        
    }

    
}
