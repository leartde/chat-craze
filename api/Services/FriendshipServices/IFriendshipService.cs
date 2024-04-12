using api.DataTransferObjects.FriendshipDtos;
using api.Models;

namespace api.Services.FriendshipServices;

public interface IFriendshipService
{
    Task<IEnumerable<FriendshipDto>> GetFriendshipsForUserAsync(string userId);
    Task CreateFriendshipAsync(string friendOneId, string friendTwoId);
    Task DeleteFriendshipAsync(string friendOneId, string friendTwoId);
}