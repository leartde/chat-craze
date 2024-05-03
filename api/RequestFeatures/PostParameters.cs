namespace api.RequestFeatures
{
    public class PostParameters : RequestParameters
    {
        public PostParameters() => OrderBy = "createdAt";
        public string? Category { get; set; }
        public string? UserName { get; set; }
        public int MinLikes { get; set; } = 0;
        public string? SearchTerm { get; set; }

    }
}
