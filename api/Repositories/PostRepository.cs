using api.Contracts;
using api.Data;
using api.Models;

namespace api.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context) { }
        public void CreatePost(Post post)
        {
            Create(post);
        }

        public void DeletePost(Post post)
        {
            Delete(post);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return FindAll()
                  .OrderBy(p => p.Title)
                  .ToList();
        }

        public Post GetPost(int id)
        {
            return FindByCondition(p => p.Id == id)
                   .SingleOrDefault()
                ;
        }

        public void UpdatePost(Post post)
        {
            Update(post);
        }
    }
}
