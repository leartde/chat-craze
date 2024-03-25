using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Reply
    {
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get;set; }
        public AppUser? User { get; set; }
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public Comment? Comment { get; set; }
        [Required(ErrorMessage ="Reply content is required.")]
        [MaxLength(60,ErrorMessage ="Reply can't be more than 60 characters long.")]
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
