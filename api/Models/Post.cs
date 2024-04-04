using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Post Title is required.")]
        [MaxLength(65,ErrorMessage ="Title can't be more than 65 characters long")]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public AppUser? User { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? ImageUrl { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Like>? Likes { get; set; }
    }
}
