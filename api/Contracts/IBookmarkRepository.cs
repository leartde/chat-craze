using api.Models;

namespace api.Contracts;

public interface IBookmarkRepository
{
    Task<IEnumerable<Bookmark>> GetBookmarksForUserAsync(string userId);
    void CreateBookmark(Bookmark bookmark);
    void DeleteBookmark(Bookmark bookmark);
}