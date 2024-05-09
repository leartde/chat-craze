using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Notification
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Receiver))]
        public string ReceiverId { get; set; } = string.Empty;
        public AppUser? Receiver { get; set; }
        [ForeignKey(nameof(Sender))]
        public string? SenderId { get; set; }
        public AppUser? Sender { get; set; }
        [Required]
        [MaxLength(80,ErrorMessage = "Max length reached.")]
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool? IsRead { get; set; } = false;
    }
}
