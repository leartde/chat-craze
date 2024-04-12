using api.Models;

namespace api.Contracts;

public interface IReplyRepository
{
    Task<IEnumerable<Reply>> GetRepliesForCommentAsync(int commentId);
    Task<Reply?> GetReplyForCommentAsync(int commentId, int id);
    void CreateReply(Reply reply);
    void UpateReply(Reply reply);
    void DeleteReply(Reply reply);
}