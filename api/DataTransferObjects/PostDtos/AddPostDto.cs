using System.ComponentModel.DataAnnotations;

namespace api.DataTransferObjects.PostDtos;

public class AddPostDto
{
    public string? Title { get; set; }
    public string?  UserId { get; set; }
    public string? Content { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? Category { get; set; }
    public DateTime CreatedAt { get; set; }
    
}