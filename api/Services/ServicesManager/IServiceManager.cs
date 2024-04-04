using api.Services.BookmarkServices;
using api.Services.FriendshipServices;
using api.Services.InvitationServices;
using api.Services.LikeServices;
using api.Services.NotificationServices;
using api.Services.PostServices;
using api.Services.UserServices;
using api.Services.UsersInterestsServices;

namespace api.Services.ServicesManager
{
    public interface IServiceManager
    {
        IPostService PostService { get; }
        IUserService UserService { get; }
        IInvitationService InvitationService { get; }
        INotificationService NotificationService { get; }
        IFriendshipService FriendshipService { get; }
        ILikeService LikeService { get; }
        IBookmarkService BookmarkService { get; }
        IUsersInterestsService UsersInterestsService { get; }
         
    }
}
