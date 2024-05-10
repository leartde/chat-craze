using System.ComponentModel.DataAnnotations;
using api.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Sender))]
        public string SenderId { get; set; } = string.Empty;

        [Required] public AppUser? Sender { get; set; }

        [ForeignKey(nameof(Receiver))]
        public string ReceiverId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public AppUser? Receiver { get; set; }
        public string Status { get; set; } = "Pending";


    }
}
