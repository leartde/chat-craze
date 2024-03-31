using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? RefreshToken { get; set; } 
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string? AvatarUrl { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
