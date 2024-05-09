using System.ComponentModel.DataAnnotations;

namespace api.DataTransferObjects.UserDtos;

public class UpdateUserDto
{
    [Required(ErrorMessage = "Username is required.")]
    [Length(4, 20, ErrorMessage = "Username must be between 6 and 20 characters.")]
    public string UserName { get; init; } = string.Empty;
    
    [Required(ErrorMessage = "Email is required.")]
    [MaxLength(40)]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; init; }  = string.Empty;

}