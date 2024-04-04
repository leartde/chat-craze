using api.DataTransferObjects.LikeDtos;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("/api/likes")]
public class LikeController : ControllerBase
{
    private readonly IServiceManager _service;

    public LikeController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetLikesForUser(string userId)
    {
        var likes = await _service.LikeService.GetLikesForUserAsync(userId);
        return Ok(likes);
    }

    [HttpGet("post/{postId}")]
    public async Task<IActionResult> GetLikesForPost(int postId)
    {
        var likes = await _service.LikeService.GetLikesForPostAsync(postId);
        return Ok(likes);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLike(AddLikeDto addLikeDto)
    {
        await _service.LikeService.AddLikeAsync(addLikeDto);
        return Ok($"Like successfully added.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteLike(DeleteLikeDto deleteLikeDto)
    {
        await _service.LikeService.RemoveLikeAsync(deleteLikeDto);
        return Ok("Like successfully removed.");
    }
}