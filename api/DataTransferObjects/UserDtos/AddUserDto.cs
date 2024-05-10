using System.ComponentModel.DataAnnotations;

namespace api.DataTransferObjects.UserDtos
{
    public class AddUserDto
    {
        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(16,ErrorMessage = "Max username length is 16 characters")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email address is required.")]
        public string Email { get; set; } = string.Empty;
    }
}
