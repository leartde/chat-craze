namespace api.DataTransferObjects.PostDtos
{
    namespace api.DataTransferObjects.PostDtos
    {
        public class PostDto
        {
            public int Id { get; set; }
            public string UserId { get; set; } = string.Empty;
            public string Title { get; set; } = string.Empty;
            public string Content { get; set; } = string.Empty;
            public string UserName { get; set; } = string.Empty;
            public string Category { get; set; } = string.Empty;
            public DateTime CreatedAt { get; set; }
            public string? ImageUrl { get; set; }
            public int LikeCount { get; set; } = 0;
        }
    }
}
