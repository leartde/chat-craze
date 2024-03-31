using System.ComponentModel.DataAnnotations;

namespace api.DataTransferObjects.UserDtos
{
    public class AddUserDto
    {
        [Required(ErrorMessage = "Username is required.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Email address is required.")]
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
