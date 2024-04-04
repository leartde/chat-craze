using api.DataTransferObjects.PostDtos;
using api.RequestFeatures;

namespace api.Services.PostServices
{
    public interface IPostService
    {
        Task<(IEnumerable<PostDto> posts, MetaData metaData)> GetAllPostsAsync(PostParameters postParameters);
        Task<PostDto> GetPostAsync(int id);
        Task DeletePostAsync(int id);

    }
}
