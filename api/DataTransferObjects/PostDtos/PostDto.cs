namespace api.DataTransferObjects.PostDtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? UserName { get; set; }
        public string? Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ImageUrl { get; set; }
        public int? LikeCount { get; set; }
    }
}
