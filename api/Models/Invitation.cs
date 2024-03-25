using api.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Invitation
    {
        [Column("InvitationId")]
        public int Id { get; set; }
        [ForeignKey(nameof(Sender))]
        public int SenderId { get; set; }
        public AppUser? Sender { get; set; }
        [ForeignKey(nameof(Receiver))]
        public int ReceiverId { get; set; }
        public AppUser? Receiver { get; set; }
        public InvitationStatus Status { get; set; } = 0;
        

    }
}
