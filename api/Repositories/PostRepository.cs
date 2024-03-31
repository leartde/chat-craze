using api.Contracts;
using api.Data;
using api.Models;
using api.Repositories.Extensions;
using api.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context) { }

        public void CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(Post post)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<Post>> GetAllPostsAsync(PostParameters postParameters)
        {
            var posts = await FindAll()
                .Include(p => p.User)
                .FilterPosts(postParameters.Category, postParameters.UserName)
                .Search(postParameters.SearchTerm)
                .ToListAsync();
            return PagedList<Post>.ToPagedList(posts, postParameters.PageNumber
                , postParameters.PageSize);
        }

        public async Task<Post> GetPostAsync(int id)
        {
            return await FindByCondition(p => p.Id == id)
                         .Include(p => p.User)
                          .FirstOrDefaultAsync();
                
        }

        public async Task<IEnumerable<Post>> GetPostsByCategoryAsync(string category)
        {
            return await FindByCondition(p => p.Category == category)
                .Include(p => p.User)
                .ToListAsync();
        }

        public Task<IEnumerable<Post>> GetPostsByUserAsync(string username)
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
