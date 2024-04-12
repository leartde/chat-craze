using api.DataTransferObjects.CommentDtos;

namespace api.Services.CommentServices
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetCommentsForPostAsync(int postId);
        Task<CommentDto> GetCommentForPostAsync(int id, int postId);
        Task<IEnumerable<CommentDto>> GetCommentsForUserAsync(string userId);
        Task CreateCommentAsync(int postId, AddCommentDto commentDto);
        Task UpdateCommentAsync(int id, int postId, UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(int id, int postId);


    }
}
