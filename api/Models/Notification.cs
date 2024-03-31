using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Notification
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Receiver))]
        public string ReceiverId { get; set; }
        public AppUser? Receiver { get; set; }
        [ForeignKey(nameof(Sender))]
        public string SenderId { get; set; }
        public AppUser? Sender { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool isRead { get; set; } = false;
    }
}
