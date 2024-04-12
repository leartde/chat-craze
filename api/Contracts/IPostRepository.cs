using api.Models;
using api.RequestFeatures;

namespace api.Contracts
{
    public interface IPostRepository
    {
        Task <PagedList<Post>> GetAllPostsAsync(PostParameters postParameters);
        Task <Post?> GetPostAsync(int id);
        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
    }
}
