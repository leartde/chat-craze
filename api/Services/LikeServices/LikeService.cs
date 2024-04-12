using api.Contracts;
using api.DataTransferObjects.LikeDtos;
using api.Exceptions;
using api.Models;
using AutoMapper;

namespace api.Services.LikeServices;

public class LikeService : ILikeService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public LikeService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<LikeDto>> GetLikesForPostAsync(int postId)
    {
        await CheckIfPostExistsAsync(postId);
        var likes = await _repository.Like.GetLikesByPostAsync(postId);
        return _mapper.Map<IEnumerable<LikeDto>>(likes);
    }

    public async Task<IEnumerable<LikeDto>> GetLikesForUserAsync(string userId)
    {
        await CheckIfUserExistsAsync(userId);
        var likes = await _repository.Like.GetLikesByUserAsync(userId);
        return _mapper.Map<IEnumerable<LikeDto>>(likes);
    }

    public async Task AddLikeAsync(int postId, string userId)
    {
        await CheckIfLikeExistsAsync(userId, postId);
        var like = new Like
        {
            PostId = postId,
            UserId = userId
        };
         _repository.Like.AddLike(like);
         await _repository.SaveAsync();
    }

    public async Task RemoveLikeAsync(int postId, string userId)
    {
        var likes = await _repository.Like.GetLikesByUserAsync(userId);
        var likeToDelete = likes.FirstOrDefault(l => l.PostId.Equals(postId));
        if (likeToDelete is null) throw new NotFoundException("Like doesn't exist");
            _repository.Like.RemoveLike(likeToDelete);
            await _repository.SaveAsync();
        
    }
    
    private async Task CheckIfPostExistsAsync(int postId)
    {
        var post = await _repository.Post.GetPostAsync(postId);
        if (post is null) throw new NotFoundException($"Post with id {postId} not found.");
    }
    private async Task CheckIfUserExistsAsync(string userId)
    {
        var user = await _repository.User.GetUserAsync(userId);
        if (user is null) throw new NotFoundException($"User with id {userId} not found.");
    }

    private async Task CheckIfLikeExistsAsync(string userId, int postId)
    {
        var likes = await _repository.Like.GetLikesByUserAsync(userId);
        if (likes != null && likes.Any(l => l.PostId.Equals(postId)))
        {
            throw new BadRequestException("Like already exists.");
        }
    }
}