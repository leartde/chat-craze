namespace api.DataTransferObjects.CommentDtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int PostId { get; set; }
        public string? Content { get; set; }
        public string? Username { get; set; }
        public string? UserAvatar { get; set; }
        public string? PostTitle { get; set; }
        

    }
}
