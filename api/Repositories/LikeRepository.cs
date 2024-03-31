using api.Contracts;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class LikeRepository : RepositoryBase<Like>, ILikeRepository
    {
        public LikeRepository(ApplicationDbContext context) : base(context) { }
        public void AddLike(Post post, AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Like>> GetLikesByPostAsync(int postId)
        {
            return await FindByCondition(l => l.PostId == postId)
                    .AsNoTracking()
                    .ToListAsync();
        }

        public Task<IEnumerable<Like>> GetLikesByUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveLike(Like like)
        {
            throw new NotImplementedException();
        }
    }
}
