﻿namespace api.DataTransferObjects
{
    public class PostDto
    {
        public int Id { get; set; }
        public int UserId {  get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ImageUrl { get; set; }
    }
}
