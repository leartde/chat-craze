using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Friendship
    {
        public int Id { get; set; }
        [ForeignKey(nameof(FriendOne))]
        public int FriendOneId { get; set; }
        public AppUser? FriendOne { get; set; }
        [ForeignKey(nameof(FriendTwo))]
        public int FriendTwoId { get; set; }
        public AppUser? FriendTwo { get; set; }
    }
}
