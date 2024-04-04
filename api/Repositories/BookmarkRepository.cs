using api.Contracts;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class BookmarkRepository : RepositoryBase<Bookmark>, IBookmarkRepository
{
    public BookmarkRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Bookmark>> GetBookmarksForUserAsync(string userId)
    {
        return await FindByCondition(b => b.UserId.Equals(userId))
            .Include(b => b.Post)
            .ToListAsync();
    }

    public void CreateBookmark(Bookmark bookmark)
    {
        Create(bookmark);
    }

    public void DeleteBookmark(Bookmark bookmark)
    {
        Delete(bookmark);
    }
}