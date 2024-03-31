using api.Contracts;
using api.DataTransferObjects.PostDtos;
using api.RequestFeatures;
using AutoMapper;

namespace api.Services.PostServices
{
    internal sealed class PostService : IPostService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public PostService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<(IEnumerable<PostDto> posts, MetaData metaData)> GetAllPostsAsync(
          PostParameters postParameters
          )
        {
            var postsWithMetaData = await _repository.Post.GetAllPostsAsync(postParameters);
            var postDtos = _mapper.Map<IEnumerable<PostDto>>(postsWithMetaData);
            return (postDtos, postsWithMetaData.MetaData);
        }

        public async Task<PostDto> GetPostAsync(int id)
        {
            var post = await _repository.Post.GetPostAsync(id);
            var postDto = _mapper.Map<PostDto>(post);
            return postDto;
        }

        public async Task<IEnumerable<PostDto>> GetPostsByCategoryAsync(string category)
        {
            var posts = await _repository.Post.GetPostsByCategoryAsync(category);
            var postDtos = _mapper.Map<IEnumerable<PostDto>>(posts);
            return postDtos;
        }

        public Task<IEnumerable<PostDto>> GetPostsByUserAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
    
}
