using api.DataTransferObjects.LikeDtos;

namespace api.Services.LikeServices;

public interface ILikeService
{
    public Task<IEnumerable<LikeDto>> GetLikesForPostAsync(int postId);
    public Task<IEnumerable<LikeDto>> GetLikesForUserAsync(string userId);
    public Task AddLikeAsync(int postId, string userId);
    public Task RemoveLikeAsync(int postId, string userId);
}