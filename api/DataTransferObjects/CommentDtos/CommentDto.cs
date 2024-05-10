namespace api.DataTransferObjects.CommentDtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int PostId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string UserAvatar { get; set; } = string.Empty;
        public string PostTitle { get; set; } = string.Empty;


    }
}
