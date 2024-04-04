using api.Contracts;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class LikeRepository : RepositoryBase<Like>, ILikeRepository
    {
        public LikeRepository(ApplicationDbContext context) : base(context) { }
        public void AddLike(Like like)
        {
            Create(like);
        }

        public async Task<IEnumerable<Like>> GetLikesByPostAsync(int postId)
        {
            return await FindByCondition(l => l.PostId == postId)
                .Include(l => l.User)
                .Include(l => l.Post)
                    .ToListAsync();
        }

        public async Task<IEnumerable<Like>> GetLikesByUserAsync(string userId)
        {
            return await FindByCondition(l => l.UserId == userId)
                .Include(l => l.User)
                .Include(l => l.Post)
                .ToListAsync();
        }

        public void RemoveLike(Like like)
        {
            Delete(like);
        }
    }
}
