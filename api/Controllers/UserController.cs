using api.DataTransferObjects.UserDtos;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _service;

        public UserController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }

        [HttpPost("authentication/register")]
        public async Task<IActionResult> RegisterUser([FromBody] AddUserDto addUserDto)
        {
            var result = await _service.UserService.RegisterUser(addUserDto);
            if (result.Succeeded) return Ok(result);
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);

        }

        [HttpPost("authentication/login")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserDto user)
        {
            if (!await _service.UserService.ValidateUser(user)) return Unauthorized();
            var tokenDto = await _service.UserService.CreateToken(populateExp: true);
            return Ok(tokenDto);
        }

        [HttpPost("authentication/refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _service.UserService.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _service.UserService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _service.UserService.GetUserAsync(id);
            return Ok(user);
        }

        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await _service.UserService.GetUserByUsernameAsync(username);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UpdateUserDto updateUserDto)
        {
            await _service.UserService.UpdateUserAsync(id, updateUserDto);
            return Ok(
                $"User with id {id} successfully updated with new details: {updateUserDto.UserName}\n{updateUserDto.Email}");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _service.UserService.DeleteUserAsync(id);
            return Ok("User successfully deleted");
        }

        [HttpPost("authentication/logout")]
        public  IActionResult DeleteCookie()
        {
             var delete = _service.UserService.DestroyTokens();
             if (delete) return Ok("Tokens deleted.");
             return BadRequest("Error deleting tokens");
        }
    }
}

