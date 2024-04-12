using api.DataTransferObjects.LikeDtos;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("/api/posts/{postId}/likes")]
public class LikeController : ControllerBase
{
    private readonly IServiceManager _service;

    public LikeController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("/api/users/{userId}/likes")]
    public async Task<IActionResult> GetLikesForUser(string userId)
    {
        var likes = await _service.LikeService.GetLikesForUserAsync(userId);
        return Ok(likes);
    }

    [HttpGet]
    public async Task<IActionResult> GetLikesForPost(int postId)
    {
        var likes = await _service.LikeService.GetLikesForPostAsync(postId);
        return Ok(likes);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLike(int postId, string userId)
    {
        await _service.LikeService.AddLikeAsync(postId, userId);
        return Ok($"Like successfully added.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteLike(int postId, string userId)
    {
        await _service.LikeService.RemoveLikeAsync(postId, userId);
        return Ok("Like successfully removed.");
    }
}