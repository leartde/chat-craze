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
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null?src.User.UserName:string.Empty))
              .ForMember(dest => dest.LikeCount, opt => opt.MapFrom<LikesResolver>());

            CreateMap<AddPostDto, Post>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
                
            
            CreateMap<AddUserDto, AppUser>();
            CreateMap<UpdateUserDto, AppUser>();
            CreateMap<AppUser, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom<RolesResolver>());
            
            CreateMap<Invitation, InvitationDto>()
                .ForMember(dest => dest.SenderUsername, opt => opt.MapFrom(src => src.Sender != null?src.Sender.UserName:string.Empty))
                .ForMember(dest => dest.ReceiverUsername, opt => opt.MapFrom(src => src.Receiver!=null?src.Receiver.UserName:string.Empty));
                
            CreateMap<Notification, NotificationDto>()
                .ForMember(dest => dest.SenderUsername, opt => opt.MapFrom(src => src.Sender != null?src.Sender.UserName:string.Empty))
                .ForMember(dest => dest.ReceiverUsername, opt => opt.MapFrom(src => src.Receiver!=null?src.Receiver.UserName:string.Empty));
            CreateMap<AddNotificationDto, NotificationDto>();


            CreateMap<Friendship, FriendshipDto>()
                .ForMember(dest => dest.FriendOneUsername, opt => opt.MapFrom(src => src.FriendOne != null?src.FriendOne.UserName:string.Empty))
                .ForMember(dest => dest.FriendOneAvatar, opt => opt.MapFrom(src => src.FriendOne != null?src.FriendOne.AvatarUrl:string.Empty))
                .ForMember(dest => dest.FriendTwoUsername, opt => opt.MapFrom(src => src.FriendTwo != null?src.FriendTwo.UserName:string.Empty))
                .ForMember(dest => dest.FriendTwoAvatar, opt => opt.MapFrom(src => src.FriendTwo != null?src.FriendTwo.AvatarUrl:string.Empty));

            CreateMap<Like, LikeDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User != null?src.User.UserName:string.Empty))
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Post != null?src.Post.Title:string.Empty));
        

            CreateMap<Bookmark, BookmarkDto>()
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Post != null?src.Post.Title:string.Empty))
                .ForMember(dest => dest.PostImage, opt => opt.MapFrom(src => src.Post != null?src.Post.ImageUrl:string.Empty));

            CreateMap<UsersInterests, UsersInterestsDto>().ReverseMap();

            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User != null?src.User.UserName:string.Empty))
                .ForMember(dest => dest.UserAvatar, opt => opt.MapFrom(src => src.User != null?src.User.AvatarUrl:string.Empty))
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Post != null?src.Post.Title:string.Empty));
            CreateMap<AddCommentDto, Comment>();
            CreateMap<UpdateCommentDto, Comment>();

            CreateMap<Reply, ReplyDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User != null?src.User.UserName:string.Empty))
                .ForMember(dest => dest.UserAvatar, opt => opt.MapFrom(src => src.User != null?src.User.AvatarUrl:string.Empty));
            CreateMap<AddReplyDto, Reply>();
        }
        
    }

    
}
