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
        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _postRepository = new Lazy<IPostRepository>(() => new PostRepository(context));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(context));
            _likeRepository = new Lazy<ILikeRepository>(() => new LikeRepository(context));
        }
        public IPostRepository Post => _postRepository.Value;
        public IUserRepository User => _userRepository.Value;
        public ILikeRepository Like => _likeRepository.Value;


        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
