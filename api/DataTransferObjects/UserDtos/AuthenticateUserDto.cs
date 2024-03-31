using System.ComponentModel.DataAnnotations;

namespace api.DataTransferObjects.UserDtos
{
    public class AuthenticateUserDto
    {
        [Required(ErrorMessage ="Username is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage ="Password is required")]
        public string? Password { get; init; }
    }
}
