using api.Contracts;
using api.DataTransferObjects.PostDtos;
using api.Exceptions;
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
            await CheckIfPostExistsAsync(id);
            var post = await _repository.Post.GetPostAsync(id);
            return _mapper.Map<PostDto>(post);
        }

        public async Task DeletePostAsync(int id)
        {
            await CheckIfPostExistsAsync(id);
            var post = await _repository.Post.GetPostAsync(id);
            _repository.Post.DeletePost(post);
            await _repository.SaveAsync();
        }

        private async Task CheckIfPostExistsAsync(int postId)
        {
            var post = await _repository.Post.GetPostAsync(postId);
            if (post is null) throw new NotFoundException($"Post with id {postId} not found.");
        }
    }
    
}
