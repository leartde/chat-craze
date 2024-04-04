using api.Models;

namespace api.Contracts;

public interface IUsersInterestsRepository
{
    Task<IEnumerable<UsersInterests>> GetUsersInterestsForUserAsync(string userId);
    void CreateUsersInterests(UsersInterests usersInterest);
    void DeleteUsersInterests(UsersInterests usersInterest);
    void UpdateUsersInterests(UsersInterests usersInterest);
}