using api.DataTransferObjects.BookmarkDtos;
using api.Models;

namespace api.Services.BookmarkServices;

public interface IBookmarkService
{
    Task<IEnumerable<BookmarkDto>> GetBookmarksForUserAsync(string userId);
    Task CreateBookmarkAsync(AddBookmarkDto addBookmarkDto);
    Task DeleteBookmarkAsync(DeleteBookmarkDto deleteBookmarkDto);
}