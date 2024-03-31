using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Like
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public Post? Post { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public AppUser? User { get; set; }
    }
}
