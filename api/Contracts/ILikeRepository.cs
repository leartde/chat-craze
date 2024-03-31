using api.Models;

namespace api.Contracts
{
    public interface ILikeRepository
    {
        Task<IEnumerable<Like>> GetLikesByPostAsync(int postId);
        Task<IEnumerable<Like>> GetLikesByUserAsync(string userId);
        void AddLike (Post post, AppUser appUser);
        void RemoveLike(Like like);
    }
}
