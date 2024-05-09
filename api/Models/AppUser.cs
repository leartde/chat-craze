using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string AvatarUrl { get; set; } = string.Empty;
        public  ICollection<Post> Posts { get; set; } = new List<Post>();
        public  ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}