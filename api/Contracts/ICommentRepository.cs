using api.Models;

namespace api.Contracts
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsForPostAsync(int postId);
        Task<IEnumerable<Comment>> GetCommentsForUserAsync(string userId);
        Task<Comment?> GetCommentForPostAsync(int id, int postId);
        void CreateComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(Comment comment);
    }
}
