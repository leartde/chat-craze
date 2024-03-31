using api.DataTransferObjects;
using api.RequestFeatures;

namespace api.Services.PostServices {
    public interface IPostService
    {
        Task<(IEnumerable<PostDto> posts, MetaData metaData)> GetAllPostsAsync(PostParameters postParameters);
        Task<PostDto> GetPostAsync(int id);
        Task<IEnumerable<PostDto>> GetPostsByCategoryAsync(string category);
        Task<IEnumerable<PostDto>> GetPostsByUserAsync(string username);
    }
}
