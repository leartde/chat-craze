using api.DataTransferObjects.BookmarkDtos;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("/api/users/{userId}/bookmarks")]
public class BookmarkController : ControllerBase
{
    private readonly IServiceManager _service;

    public BookmarkController(IServiceManager service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetBookmarksForUser(string userId)
    {
        var bookmarks = await _service.BookmarkService.GetBookmarksForUserAsync(userId);
        return Ok(bookmarks);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookmark(string userId, int postId)
    {
        await _service.BookmarkService.CreateBookmarkAsync(userId, postId);
        return Ok("Bookmark successfully created.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBookmark(string userId, int postId)
    {
        await _service.BookmarkService.DeleteBookmarkAsync(userId, postId);
        return Ok("Bookmark successfully deleted.");
    }
}