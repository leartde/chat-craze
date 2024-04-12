using api.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class UsersInterests
    {
        [Key]
        public int InterestId { get; set; }
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
        
        public string? Interest { get; set; }
    }
}
