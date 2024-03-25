using api.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class UsersInterests
    {
        [Key]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public AppUser? User { get; set; }
        public Interests Interest { get; set; }
    }
}
