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
            Update(post);
        }

        public void DeletePost(Post post)
        {
            Delete(post);
        }

        public async Task<PagedList<Post>> GetAllPostsAsync(PostParameters postParameters)
        {
            var posts = await FindAll()
                .Include(p => p.User)
                .Include(p => p.Likes)
                .Filter(postParameters.Category, postParameters.UserName)
                .Search(postParameters.SearchTerm)
                .Sort(postParameters.OrderBy)
                .ToListAsync();
            return PagedList<Post>.ToPagedList(posts, postParameters.PageNumber
                , postParameters.PageSize);
        }

        public async Task<Post?> GetPostAsync(int id)
        {
            return await FindByCondition(p => p.Id == id)
                         .Include(p => p.User)
                         .Include(p => p.Likes)
                          .FirstOrDefaultAsync();

        }
        
        public void UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}