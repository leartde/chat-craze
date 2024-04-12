using api.Contracts;
using api.DataTransferObjects.BookmarkDtos;
using api.Exceptions;
using api.Models;
using AutoMapper;

namespace api.Services.BookmarkServices;

public class BookmarkService : IBookmarkService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public BookmarkService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<BookmarkDto>> GetBookmarksForUserAsync(string userId)
    {
        var bookmarks = await _repository.Bookmark.GetBookmarksForUserAsync(userId);
        return _mapper.Map<IEnumerable<BookmarkDto>>(bookmarks);
    }

    public async Task CreateBookmarkAsync(string userId, int postId)
    {
        var bookmark = new Bookmark
        {
            UserId = userId,
            PostId = postId
        };
        _repository.Bookmark.CreateBookmark(bookmark);
        await _repository.SaveAsync();
    }

    public async Task DeleteBookmarkAsync(string userId, int postId)
    {
        var bookmarks = await _repository.Bookmark.GetBookmarksForUserAsync(userId);
        var bookmarkToDelete = bookmarks.FirstOrDefault(b => b.PostId.Equals(postId));
        if (bookmarkToDelete is null) throw new NotFoundException("Bookmark not found.");
            _repository.Bookmark.DeleteBookmark(bookmarkToDelete);
            await _repository.SaveAsync();
        

    }

 
}