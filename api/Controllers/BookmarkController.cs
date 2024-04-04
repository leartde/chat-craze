using api.DataTransferObjects.BookmarkDtos;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("/api/bookmarks")]
public class BookmarkController : ControllerBase
{
    private readonly IServiceManager _service;

    public BookmarkController(IServiceManager service)
    {
        _service = service;
    }
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetBookmarksForUser(string userId)
    {
        var bookmarks = await _service.BookmarkService.GetBookmarksForUserAsync(userId);
        return Ok(bookmarks);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookmark(AddBookmarkDto addBookmarkDto)
    {
        await _service.BookmarkService.CreateBookmarkAsync(addBookmarkDto);
        return Ok("Bookmark successfully created.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBookmark(DeleteBookmarkDto deleteBookmarkDto)
    {
        await _service.BookmarkService.DeleteBookmarkAsync(deleteBookmarkDto);
        return Ok("Bookmark successfully deleted.");
    }
}