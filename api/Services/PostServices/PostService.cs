using api.Contracts;
using api.DataTransferObjects.PostDtos;
using api.DataTransferObjects.PostDtos.api.DataTransferObjects.PostDtos;
using api.Exceptions;
using api.Models;
using api.RequestFeatures;
using api.Services.PhotoServices;
using AutoMapper;

namespace api.Services.PostServices
{
    internal sealed class PostService : IPostService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        public PostService(IRepositoryManager repository, IMapper mapper, IPhotoService photoService)
        {
            _repository = repository;
            _mapper = mapper;
            _photoService = photoService;
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
            var post = await FetchPost(id);
            return _mapper.Map<PostDto>(post);
        }

        public async Task AddPostAsync(AddPostDto postDto)
        {
            if(postDto.ImageFile is null) throw new BadRequestException("Image is null");
            var photoResult = await _photoService.AddPhotoAsync(postDto.ImageFile);
            if(photoResult.Error != null) throw new Exception(photoResult.Error.Message);
           var post = _mapper.Map<Post>(postDto);
           post.ImageUrl = photoResult.Url.ToString();
            _repository.Post.CreatePost(post);
            await _repository.SaveAsync();

        }

        public async Task DeletePostAsync(int id)
        {
            var post = await FetchPost(id);
            _repository.Post.DeletePost(post);
            await _repository.SaveAsync();
        }

        private async Task<Post> FetchPost(int postId)
        {
            var post = await _repository.Post.GetPostAsync(postId);
            if (post is null) throw new NotFoundException($"Post with id {postId} not found.");
            return post;
        }
    }
    
}
