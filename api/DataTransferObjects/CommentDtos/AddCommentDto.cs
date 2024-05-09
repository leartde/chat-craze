using System.ComponentModel.DataAnnotations;

namespace api.DataTransferObjects.CommentDtos
{
    public class AddCommentDto
    {
        [Required]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
    }
}
