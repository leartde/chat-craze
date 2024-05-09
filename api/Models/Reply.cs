using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Reply
    {
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get;set; } = string.Empty;
        public AppUser? User { get; set; }
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public Comment? Comment { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
