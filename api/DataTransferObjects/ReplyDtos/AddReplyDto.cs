using System.ComponentModel.DataAnnotations;

namespace api.DataTransferObjects.ReplyDtos;

public class AddReplyDto
{
    [Required]
    public string UserId { get; set; } = string.Empty;
    [Required(ErrorMessage ="Reply content is required.")]
    [MaxLength(60,ErrorMessage ="Reply can't be more than 60 characters long.")]
    public string Content { get; set; } = string.Empty;
}