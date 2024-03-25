using api.Models;

namespace api.Contracts
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllPosts();
        Post GetPost(int id);
        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
    }
}
