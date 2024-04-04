using System.Security.Cryptography;
using api.Contracts;
using api.DataTransferObjects.BookmarkDtos;
using api.DataTransferObjects.FriendshipDtos;
using api.DataTransferObjects.InvitationDtos;
using api.DataTransferObjects.LikeDtos;
using api.DataTransferObjects.NotificationDtos;
using api.DataTransferObjects.PostDtos;
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
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
              .ForMember(dest => dest.LikeCount, opt => opt.MapFrom<LikesResolver>());
            
            CreateMap<AddUserDto, AppUser>();
            CreateMap<AppUser, UserDto>();
            
            CreateMap<Invitation, InvitationDto>()
                .ForMember(dest => dest.SenderUsername, opt => opt.MapFrom(src => src.Sender.UserName))
                .ForMember(dest => dest.ReceiverUsername, opt => opt.MapFrom(src => src.Receiver.UserName));
            CreateMap<AddInvitationDto, Invitation>();
            CreateMap<UpdateInvitationDto, Invitation>();
                
            CreateMap<Notification, NotificationDto>()
                .ForMember(dest => dest.SenderUsername, opt => opt.MapFrom(src => src.Sender.UserName))
                .ForMember(dest => dest.ReceiverUsername, opt => opt.MapFrom(src => src.Receiver.UserName));
            CreateMap<AddNotificationDto, Notification>();

            CreateMap<Friendship, FriendshipDto>()
                .ForMember(dest => dest.FriendOneUsername, opt => opt.MapFrom(src => src.FriendOne.UserName))
                .ForMember(dest => dest.FriendOneAvatar, opt => opt.MapFrom(src => src.FriendOne.AvatarUrl))
                .ForMember(dest => dest.FriendTwoUsername, opt => opt.MapFrom(src => src.FriendTwo.UserName))
                .ForMember(dest => dest.FriendTwoAvatar, opt => opt.MapFrom(src => src.FriendTwo.AvatarUrl));
            CreateMap<AddFriendshipDto, Friendship>();

            CreateMap<Like, LikeDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Post.Title));
            CreateMap<AddLikeDto, Like>();

            CreateMap<Bookmark, BookmarkDto>()
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Post.Title))
                .ForMember(dest => dest.PostImage, opt => opt.MapFrom(src => src.Post.ImageUrl));
            CreateMap<AddBookmarkDto, Bookmark>();
            CreateMap<DeleteBookmarkDto, Bookmark>();

            CreateMap<UsersInterests, UsersInterestsDto>().ReverseMap();
        }
        
    }

    
}
