using api.DataTransferObjects.FriendshipDtos;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("/api/friendships")]
public class FriendshipController : ControllerBase
{
    private readonly IServiceManager _service;

    public FriendshipController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult>  GetFriendshipsForUser(string userId)
    {
        var friendships = await _service.FriendshipService
            .GetFriendshipsForUserAsync(userId);
        return Ok(friendships);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFriendship(AddFriendshipDto addFriendshipDto)
    {
        await _service.FriendshipService.CreateFriendshipAsync(addFriendshipDto);
        return Ok("Friendship succesfully created");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFriendship(DeleteFriendshipDto deleteFriendshipDto)
    {
        await _service.FriendshipService.DeleteFriendshipAsync(deleteFriendshipDto);
        return Ok("Friendship deleted successfully");
    }
}