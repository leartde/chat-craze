using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[Route("/api/authentication/users/{userId}/interests")]
public class UsersInterestsController : ControllerBase
{
    private readonly IServiceManager _service;

    public UsersInterestsController(IServiceManager service)
    {
        _service = service;
    }
    [HttpGet]
    public async  Task<IActionResult> GetInterestsForUser(string userId)
    {
        var interests = await _service
            .UsersInterestsService.GetInterestsForUserAsync(userId);
        return Ok(interests);
    }

    [HttpPost]
    public async Task<IActionResult> CreateInterestsForUser(string userId, IList<string> interests)
    {
        await _service.UsersInterestsService.AddInterestsForUserAsync(userId, interests);
        return Ok("Interests successfully added.");
    }
}