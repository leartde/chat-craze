using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Post
    {
        public int Id { get; set; }
        
        [ForeignKey(nameof(User))]
        [Required]
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
        [Required(ErrorMessage ="Post content is required.")]
        [MaxLength(65,ErrorMessage ="Title can't be more than 65 characters long")]
        public string? Title { get; set; }
        [Required(ErrorMessage ="Post content is required.")]
        [MaxLength(1000,ErrorMessage ="Title can't be more than 1000 characters long")]
        public string? Content { get; set; }
        
        public string? Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? ImageUrl { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Like>? Likes { get; set; }
    }
}
