using api.Contracts;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;

namespace api.Repositories
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Comment?> GetCommentForPostAsync(int id, int postId)
        {
            return await FindByCondition(c => c.PostId == postId && c.Id == id)
                .Include(c => c.User)
                .Include(c => c.Post)
                .OrderBy(c => c.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public void CreateComment(Comment comment)
        {
            Create(comment);
        }

        public void DeleteComment(Comment comment)
        {
            Delete(comment);
        }

        public async Task<IEnumerable<Comment>> GetCommentsForPostAsync(int postId)
        {
            return await FindByCondition(c => c.PostId == postId)
                    .Include(c => c.Post)
                    .Include(c => c.User)
                    .ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsForUserAsync(string userId)
        {
            return await FindByCondition(c => c.UserId.Equals(userId))
                   .Include(c => c.Post)
                   .Include(c => c.User)
                   .ToListAsync();
        }

        public void UpdateComment(Comment comment)
        {
            Update(comment);
        }
    }
}
