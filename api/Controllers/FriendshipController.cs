using api.DataTransferObjects.FriendshipDtos;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("/api/users/{userId}/friendships")]
public class FriendshipController : ControllerBase
{
    private readonly IServiceManager _service;

    public FriendshipController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult>  GetFriendshipsForUser(string userId)
    {
        var friendships = await _service.FriendshipService
            .GetFriendshipsForUserAsync(userId);
        return Ok(friendships);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFriendship(string senderId, string userId)
    {
        await _service.FriendshipService.CreateFriendshipAsync(senderId, userId);
        return Ok("Friendship succesfully created");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFriendship(string userId, string friendId)
    {
        await _service.FriendshipService.DeleteFriendshipAsync(userId, friendId);
        return Ok("Friendship deleted successfully");
    }
}