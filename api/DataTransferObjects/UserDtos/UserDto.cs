
namespace api.DataTransferObjects.UserDtos
{
    public class UserDto 
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set;}
        public string? AvatarUrl { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
