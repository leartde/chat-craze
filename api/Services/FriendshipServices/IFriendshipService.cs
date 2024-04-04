using api.DataTransferObjects.FriendshipDtos;
using api.Models;

namespace api.Services.FriendshipServices;

public interface IFriendshipService
{
    Task<IEnumerable<FriendshipDto>> GetFriendshipsForUserAsync(string userId);
    Task CreateFriendshipAsync(AddFriendshipDto addFriendshipDto);
    Task DeleteFriendshipAsync(DeleteFriendshipDto deleteFriendshipDto);
}