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
        var post = await FetchPostAsync(postId);
        var likes = await _repository.Like.GetLikesByPostAsync(post.Id);
        return _mapper.Map<IEnumerable<LikeDto>>(likes);
    }

    public async Task<IEnumerable<LikeDto>> GetLikesForUserAsync(string userId)
    {
        var user = await FetchUserAsync(userId);
        var likes = await _repository.Like.GetLikesByUserAsync(user.Id);
        return _mapper.Map<IEnumerable<LikeDto>>(likes);
    }

    public async Task AddLikeAsync(int postId, string userId)
    {
        var post = await FetchPostAsync(postId);
        var user = await FetchUserAsync(userId);
        await CheckIfLikeExistsAsync(userId, postId);
        var like = new Like
        {
            PostId = post.Id,
            UserId = user.Id
        };
         _repository.Like.AddLike(like);
         await SendLikeNotificationAsync(user.Id, post.Id);
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
    
    private async Task<Post> FetchPostAsync(int postId)
    {
        var post = await _repository.Post.GetPostAsync(postId);
        if (post is null) throw new NotFoundException($"Post with id {postId} not found.");
        return post;
    }
    private async Task<AppUser> FetchUserAsync(string userId)
    {
        var user = await _repository.User.GetUserAsync(userId);
        if (user is null) throw new NotFoundException($"User with id {userId} not found.");
        return user;
    }

    private async Task CheckIfLikeExistsAsync(string userId, int postId)
    {
        var likes = await _repository.Like.GetLikesByUserAsync(userId);
        if (likes != null && likes.Any(l => l.PostId.Equals(postId)))
        {
            throw new BadRequestException("Like already exists.");
        }
    }
    private async Task SendLikeNotificationAsync(string userId, int postId)
    {
        var post = await FetchPostAsync(postId);
        var user = await FetchUserAsync(userId);
        var notification = new Notification
        {
            SenderId = user.Id,
            ReceiverId = post.UserId,
            Content = $"{user.UserName} liked your post",
        };
        _repository.Notification.CreateNotification(notification);
        await _repository.SaveAsync();
    }
}