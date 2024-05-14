using api.DataTransferObjects.UserDtos;
using Microsoft.AspNetCore.Identity;

namespace api.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUser(AddUserDto addUserDto);
        Task<bool> ValidateUser(AuthenticateUserDto authenticateUserDto);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserAsync(string id);
        Task<UserDto> GetUserByUsernameAsync(string userName);
        Task DeleteUserAsync(string id);
        Task UpdateUserAsync(string id, UpdateUserDto updateUserDto);
        bool DestroyTokens();
    }
}
