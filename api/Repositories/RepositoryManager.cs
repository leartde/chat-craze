using api.Contracts;
using api.Data;

namespace api.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<IPostRepository> _postRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<ILikeRepository> _likeRepository;
        private readonly Lazy<IInvitationRepository> _invitationRepository;
        private readonly Lazy<INotificationRepository> _notificationRepository;
        private readonly Lazy<IFriendshipRepository> _friendshipRepository;
        private readonly Lazy<IBookmarkRepository> _bookmarkRepository;
        private readonly Lazy<IUsersInterestsRepository> _usersInterestsRepository;
        private readonly Lazy<ICommentRepository> _commentRepository;
        private readonly Lazy<IReplyRepository> _replyRepository;
        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _postRepository = new Lazy<IPostRepository>(() => new PostRepository(context));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(context));
            _likeRepository = new Lazy<ILikeRepository>(() => new LikeRepository(context));
            _invitationRepository = new Lazy<IInvitationRepository>(() => new InvitationRepository(context));
            _notificationRepository = new Lazy<INotificationRepository>(() => new NotificationRepository(context));
            _friendshipRepository = new Lazy<IFriendshipRepository>(() => new FriendshipRepository(context));
            _bookmarkRepository = new Lazy<IBookmarkRepository>(() => new BookmarkRepository(context));
            _invitationRepository = new Lazy<IInvitationRepository>(() => new InvitationRepository(context));
            _usersInterestsRepository =
                new Lazy<IUsersInterestsRepository>(() => new UsersInterestsRepository(context));
            _commentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(context));
            _replyRepository = new Lazy<IReplyRepository>(() => new ReplyRepository(context));
        }
        public IPostRepository Post => _postRepository.Value;
        public IUserRepository User => _userRepository.Value;
        public ILikeRepository Like => _likeRepository.Value;
        public IInvitationRepository Invite => _invitationRepository.Value;
        public INotificationRepository Notification => _notificationRepository.Value;
        public IFriendshipRepository Friendship => _friendshipRepository.Value;
        public IBookmarkRepository Bookmark => _bookmarkRepository.Value;
        public IUsersInterestsRepository UsersInterests => _usersInterestsRepository.Value;

        public ICommentRepository Comment => _commentRepository.Value;
        public IReplyRepository Reply => _replyRepository.Value;

        public async Task SaveAsync()
        { 
            await _context.SaveChangesAsync();
        }
    }
}
