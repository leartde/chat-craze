using api.DataTransferObjects.ReplyDtos;

namespace api.Services.ReplyServices;

public interface IReplyService
{
    public Task<IEnumerable<ReplyDto>> GetRepliesForCommentAsync(int commentId, int postId);
    public Task<ReplyDto> GetReplyForCommentAsync(int id, int commentId, int postId);
    Task CreateReplyForCommentAsync(int commentId, int postId, AddReplyDto addReplyDto);
    Task UpdateReplyForCommentAsync(string userId,int commentId, int postId);
    Task DeleteReplyForCommentAsync(string userId, int commentId, int postId);
}