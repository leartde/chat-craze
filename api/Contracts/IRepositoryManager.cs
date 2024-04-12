namespace api.Contracts
{
    public interface IRepositoryManager
    {
        IPostRepository Post { get; }
        IUserRepository User { get; }
        ILikeRepository Like { get; }  
        IInvitationRepository Invite { get; }
        INotificationRepository Notification { get; }
        IFriendshipRepository Friendship { get; }
        IBookmarkRepository Bookmark { get; }
        IUsersInterestsRepository UsersInterests { get; }
        ICommentRepository Comment { get; }
        IReplyRepository Reply { get; }
        Task SaveAsync();
    }
}
