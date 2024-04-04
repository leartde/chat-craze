using api.DataTransferObjects.UsersInterestsDtos;
using api.Models;

namespace api.Services.UsersInterestsServices;

public interface IUsersInterestsService
{
    Task<IList<string>> GetInterestsForUserAsync(string userId);
    Task AddInterestsForUserAsync(string userId, IList<string> interests);
    Task UpdateInterestsForUserAsync(ICollection<UsersInterestsDto> usersInterests);
    Task DeleteInterestsForUserAsync(ICollection<UsersInterestsDto> usersInterests);
}