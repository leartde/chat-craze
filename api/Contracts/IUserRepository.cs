using api.Models;

namespace api.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<AppUser> GetUserAsync(string id);
        void DeleteUser(AppUser user);
    }
}
