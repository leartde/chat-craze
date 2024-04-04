using api.DataTransferObjects.LikeDtos;

namespace api.Services.LikeServices;

public interface ILikeService
{
    public Task<IEnumerable<LikeDto>> GetLikesForPostAsync(int postId);
    public Task<IEnumerable<LikeDto>> GetLikesForUserAsync(string userId);
    public Task AddLikeAsync(AddLikeDto addLikeDto);
    public Task RemoveLikeAsync(DeleteLikeDto deleteLikeDto);
}