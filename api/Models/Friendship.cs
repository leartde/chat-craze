﻿using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Friendship
    {
        public int Id { get; set; }
        [ForeignKey(nameof(FriendOne))]
        public string FriendOneId { get; set; } = string.Empty;

        public AppUser? FriendOne { get; set; }
        [ForeignKey(nameof(FriendTwo))]
        public string FriendTwoId { get; set; } = string.Empty;
        public AppUser? FriendTwo { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
