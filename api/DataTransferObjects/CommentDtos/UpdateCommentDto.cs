using System.ComponentModel.DataAnnotations;

namespace api.DataTransferObjects.CommentDtos;

public class UpdateCommentDto
{
    [Required] public string Content { get; set; } = string.Empty;
}