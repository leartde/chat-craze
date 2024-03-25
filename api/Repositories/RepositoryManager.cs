using api.Contracts;
using api.Data;

namespace api.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<IPostRepository> _postRepository;
        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _postRepository = new Lazy<IPostRepository>(() => new PostRepository(context));
        }
        public IPostRepository Post => _postRepository.Value;

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
