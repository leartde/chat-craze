using api.Contracts;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class FriendshipRepository : RepositoryBase<Friendship>, IFriendshipRepository
{
    public FriendshipRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Friendship>> GetFriendshipsForUserAsync(string userId)
    {
        return await FindByCondition(f => f.FriendOneId.Equals(userId) || f.FriendTwoId.Equals(userId))
            .Include(f => f.FriendOne)
            .Include(f => f.FriendTwo).ToListAsync();
    }

    public void CreateFriendship(Friendship friendship)
    {
         Create(friendship);
    }

    public void DeleteFriendship(Friendship friendship)
    {
        Delete(friendship);
    }
}