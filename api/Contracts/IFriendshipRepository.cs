using api.Models;

namespace api.Contracts;

public interface IFriendshipRepository
{
    Task <IEnumerable<Friendship>> GetFriendshipsForUserAsync(string userId);
    void CreateFriendship(Friendship friendship);
    void DeleteFriendship(Friendship friendship);
}