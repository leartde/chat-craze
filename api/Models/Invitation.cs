using api.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Sender))]
        public string SenderId { get; set; }
        public AppUser? Sender { get; set; }
        [ForeignKey(nameof(Receiver))]
        public string ReceiverId { get; set; }
        public AppUser? Receiver { get; set; }
        public InvitationStatus Status { get; set; } = 0;
        

    }
}
