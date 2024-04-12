using api.Contracts;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class ReplyRepository : RepositoryBase<Reply>, IReplyRepository
{
    public ReplyRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Reply>> GetRepliesForCommentAsync(int commentId)
    {
       return await FindByCondition(r => r.CommentId.Equals(commentId))
            .Include(c => c.User)
            .ToListAsync();
    }

    public async Task<Reply?> GetReplyForCommentAsync(int commentId, int id)
    {
        return await FindByCondition(r => r.CommentId == commentId
                                          && r.Id == id)
            .Include(r => r.User)
            .FirstOrDefaultAsync();
    }
    
    public void CreateReply(Reply reply)
    {
        Create(reply);
    }

    public void UpateReply(Reply reply)
    {
        Update(reply);
    }

    public void DeleteReply(Reply reply)
    {
        Delete(reply);
    }
}