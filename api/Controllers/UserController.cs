using api.DataTransferObjects.UserDtos;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _service;
        public UserController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] AddUserDto addUserDto)
        {
            var result = await _service.UserService.RegisterUser(addUserDto);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserDto user)
        {
            if (!await _service.UserService.ValidateUser(user)) return Unauthorized();
            var tokenDto = await _service.UserService.CreateToken(populateExp: true);
            return Ok(tokenDto);
        }
        
        [HttpPost("refresh")]       
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _service.UserService.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
           var users = await _service.UserService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _service.UserService.GetUserAsync(id);
            return Ok(user);
        }
    }
}
