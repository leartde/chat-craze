using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public Post? Post { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage = "Comment can't be more than 100 characters long.")]
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Reply>? Replies { get; set; }
    }
}
