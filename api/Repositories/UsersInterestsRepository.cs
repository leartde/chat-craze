using api.Contracts;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class UsersInterestsRepository : RepositoryBase<UsersInterests>, IUsersInterestsRepository
{
    public UsersInterestsRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<UsersInterests>> GetUsersInterestsForUserAsync(string userId)
    {
        return await FindByCondition(u => u.UserId.Equals(userId))
            .ToListAsync();
    }

    public void CreateUsersInterests(UsersInterests usersInterest)
    {
        Create(usersInterest);
    }
    

    public void DeleteUsersInterests(UsersInterests usersInterest)
    {
        Delete(usersInterest);
    }

    public void UpdateUsersInterests(UsersInterests usersInterest)
    {
        Update(usersInterest);
    }
}