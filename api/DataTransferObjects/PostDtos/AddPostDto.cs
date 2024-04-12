using System.ComponentModel.DataAnnotations;

namespace api.DataTransferObjects.PostDtos;

public class AddPostDto
{[Required(ErrorMessage ="Post content is required.")]
    [MaxLength(65,ErrorMessage ="Title can't be more than 65 characters long")]
    public string? Title { get; set; }
    [Required(ErrorMessage ="User id is required.")]
    public string?  UserId { get; set; }
    [Required(ErrorMessage ="Post content is required.")]
    [MaxLength(1000,ErrorMessage ="Content can't be more than 1000 characters long")]
    public string? Content { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile? ImageFile { get; set; }
    [Required(ErrorMessage ="Category is required.")]
    public string? Category { get; set; }
    public DateTime CreatedAt { get; set; }
    
}