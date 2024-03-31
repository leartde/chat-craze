using api.Models;
using api.RequestFeatures;

namespace api.Contracts
{
    public interface IPostRepository
    {
        Task <PagedList<Post>> GetAllPostsAsync(PostParameters postParameters);
        Task <Post> GetPostAsync(int id);
        Task<IEnumerable<Post>> GetPostsByCategoryAsync(string category);
        Task<IEnumerable<Post>> GetPostsByUserAsync(string username);
        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
    }
}
