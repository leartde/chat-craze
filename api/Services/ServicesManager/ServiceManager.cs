using api.Contracts;
using api.Models;
using api.Services.BookmarkServices;
using api.Services.FriendshipServices;
using api.Services.InvitationServices;
using api.Services.LikeServices;
using api.Services.NotificationServices;
using api.Services.PostServices;
using api.Services.UserServices;
using api.Services.UsersInterestsServices;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace api.Services.ServicesManager
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IPostService> _postService;
        private readonly Lazy<IInvitationService> _invitationService;
        private readonly Lazy<INotificationService> _notificationService;
        private readonly Lazy<IFriendshipService> _friendshipService;
        private readonly Lazy<ILikeService> _likeService;
        private readonly Lazy<IBookmarkService> _bookmarkService;
        private readonly Lazy<IUsersInterestsService> _usersInterestsService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger,
            IMapper mapper, UserManager<AppUser> userManager, IConfiguration configuration
        )
        {
            _userService = new Lazy<IUserService>(() =>
                new UserService(repositoryManager, logger, mapper, userManager, configuration));
            _postService = new Lazy<IPostService>(() => new PostService(repositoryManager, mapper));
            _invitationService = new Lazy<IInvitationService>(() => new InvitationService(repositoryManager, mapper));
            _notificationService =
                new Lazy<INotificationService>(() => new NotificationService(repositoryManager, mapper));
            _friendshipService = new Lazy<IFriendshipService>(() => new FriendshipService(repositoryManager, mapper));
            _likeService = new Lazy<ILikeService>(() => new LikeService(repositoryManager, mapper));
            _bookmarkService = new Lazy<IBookmarkService>(() => new BookmarkService(repositoryManager, mapper));
            _usersInterestsService =
                new Lazy<IUsersInterestsService>(() => new UsersInterestsService(repositoryManager, mapper));
        }

        public IPostService PostService => _postService.Value;

        public IUserService UserService => _userService.Value;
        public IInvitationService InvitationService => _invitationService.Value;
        public INotificationService NotificationService => _notificationService.Value;
        public IFriendshipService FriendshipService => _friendshipService.Value;
        public ILikeService LikeService => _likeService.Value;
        public IBookmarkService BookmarkService => _bookmarkService.Value;
        public IUsersInterestsService UsersInterestsService => _usersInterestsService.Value;
    }
}
