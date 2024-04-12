namespace api.RequestFeatures
{
    public class PostParameters : RequestParameters
    {
        public PostParameters() => OrderBy = "createdAt";
        public string? Category { get; set; }
        public string? UserName { get; set; }
        public string? SearchTerm { get; set; }

    }
}
